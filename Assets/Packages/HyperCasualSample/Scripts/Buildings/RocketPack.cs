using System;
using System.Collections.Concurrent;
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
    public class RocketPack : MonoBehaviour
    {
        public TriggerZone TriggerZone;
        public RocketPlaceHolder Placeholder;
        
        private Sequence AnimationSequence;

        private ConcurrentQueue<Func<Task>> boxesQueue;
        private Hero _hero;
        
        private void Awake() => 
            TriggerZone.Construct(triggerStayAction: RemoveOne);

        private void RemoveOne()
        {
            
        }

        private void Start()
        {
            boxesQueue = new ConcurrentQueue<Func<Task>>();
            _hero = ServiceLocator.Instance.Single<HeroProvider>().Hero;
            Test();
        }

        public void AddOne(Transform rocket)
        {
            boxesQueue.Enqueue(async () =>
            {
                
                rocket.transform.SetParent(Placeholder.transform);
                
                var endPosition = Placeholder.GetEndPosition();
            
                rocket.transform.localPosition = endPosition;
                rocket.transform.localRotation = Quaternion.Euler(90,0,0);
                
                AnimationSequence.Append(rocket.gameObject.transform.DOScale(new Vector3(0.8f,0.8f,0.8f) ,0.4f));
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