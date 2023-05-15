using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.MainHero
{
    public class HeroBoxesPlaceholder : MonoBehaviour
    {
        public Vector3 StartPosition;
        public float YDelta;

        private float NextYPosition;

        private ConcurrentQueue<Func<Task>> boxesQueue = new ConcurrentQueue<Func<Task>>();
        private Sequence AnimationSequence;

        private void Start() => 
            Test();

        public void AddOne(Transform box)
        {
            boxesQueue.Enqueue(async () =>
            {
                box.transform.SetParent(transform);
                NextYPosition += YDelta; 
                box.transform.localPosition = StartPosition + new Vector3(0, NextYPosition, 0);
                box.transform.localRotation = Quaternion.identity;
                
                var endValue = new Vector3(StartPosition.x, NextYPosition - YDelta, StartPosition.z);
                AnimationSequence.Append(box.gameObject.transform.DOScale(new Vector3(1, 0.5f, 1), 0.1f));
                AnimationSequence.Join(box.gameObject.transform.DOLocalMove(endValue, 0.1f));
                AnimationSequence.AppendCallback(() => box.transform.localRotation = Quaternion.identity);
                Debug.LogError($"I move to {endValue}");
                await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
            });
        }

        private async UniTask Test()
        {
            while (true)
            {
                await UniTask.Yield();
                while (boxesQueue.TryDequeue(out var action))
                {
                    await action.Invoke();
                }    
            }
        }
    }
}