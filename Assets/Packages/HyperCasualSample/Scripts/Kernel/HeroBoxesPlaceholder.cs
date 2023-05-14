using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Kernel
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
                NextYPosition += YDelta;
                box.transform.localPosition = StartPosition + new Vector3(0, NextYPosition);

                box.transform.localScale = Vector3.zero;
                var endValue = new Vector3(StartPosition.x, NextYPosition - YDelta, StartPosition.z);
                AnimationSequence.Append(box.gameObject.transform.DOScale(new Vector3(1, 0.5f, 1), 1f));
                AnimationSequence.Append(box.gameObject.transform.DOLocalMove(endValue, 1));
                await Task.Delay(TimeSpan.FromSeconds(2));
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