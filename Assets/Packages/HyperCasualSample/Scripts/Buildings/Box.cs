using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Packages.HyperCasualSample.Scripts.Kernel;
using Packages.HyperCasualSample.Scripts.MainHero;
using Packages.HyperCasualSample.Scripts.Providers;
using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class Box : MonoBehaviour
    {
        public TriggerZone TriggerZone;
        public BoxPlaceholder Placeholder;
        
        private Sequence AnimationSequence;

        private ConcurrentQueue<Func<Task>> boxesQueue;
        private Hero _hero;
        
        private void Awake() => 
            TriggerZone.Construct(triggerStayAction: AddOne);

        private void Start()
        {
            boxesQueue = new ConcurrentQueue<Func<Task>>();
            _hero = ServiceLocator.Instance.Single<HeroProvider>().Hero;
            Test();
        }

        private void AddOne()
        {
            if(_hero.IsEmpty)
                return;
            
            boxesQueue.Enqueue(async () =>
            {
                var box = _hero.RemoveBoxes(); 
                
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