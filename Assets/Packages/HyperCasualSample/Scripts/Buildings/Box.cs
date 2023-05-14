using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Packages.HyperCasualSample.Scripts.Kernel;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class Box : MonoBehaviour
    {
        public TriggerZone TriggerZone;
        public BoxPlaceholder Placeholder;

        public List<Transform> Pull;

        private Sequence AnimationSequence;

        private ConcurrentQueue<Func<Task>> boxesQueue;
        
        private void Awake()
        {
            TriggerZone.Construct(triggerStayAction: AddOne);
        }

        private void Start()
        {
            boxesQueue = new ConcurrentQueue<Func<Task>>();
            Test();
        }

        private void AddOne()
        {
            boxesQueue.Enqueue(async () =>
            {
                var box = Pull.First(t => !t.gameObject.activeSelf);
                
                var endPosition = Placeholder.GetEndPosition();
                var startPosition = Placeholder.GetStartPosition();
            
                box.transform.localPosition = startPosition;
                box.gameObject.SetActive(true);
                AnimationSequence.Append(box.gameObject.transform.DOLocalJump(endPosition, 0.6f, 1, 0.1f));
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
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