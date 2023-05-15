using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    public class RocketDevelopMachine : MonoBehaviour
    {
        public TriggerZone TriggerZone;
        public RocketDevelopMachinePlaceholder Placeholder;
        
        private Sequence AnimationSequence;

        private ConcurrentQueue<Func<Task>> boxesQueue;
        private Hero _hero;

        private Stack<Transform> tools = new();
        
        public int ToolsAmount { get; private set; }
        
        private void Awake() => 
            TriggerZone.Construct(triggerStayAction: AddOne);

        private void Start()
        {
            boxesQueue = new ConcurrentQueue<Func<Task>>();
            Test();
        }

        private void AddOne()
        {
            if(!_hero)
                _hero = ServiceLocator.Instance.Single<HeroProvider>().Hero;

            if(_hero.IsEmpty)
                return;
            
            boxesQueue.Enqueue(async () =>
            {
                var box = _hero.RemoveBoxes(); 
                tools.Push(box);
                box.transform.SetParent(Placeholder.transform);
                
                var endPosition = Placeholder.GetEndPosition();
                var startPosition = Placeholder.GetStartPosition();
            
                box.transform.localPosition = startPosition;
                box.gameObject.SetActive(true);
                box.transform.localRotation = Quaternion.Euler(0,90,0);
                
                AnimationSequence.Append(box.gameObject.transform.DOLocalJump(endPosition, 0.6f, 1, 0.1f));
                AnimationSequence.AppendCallback(() => box.gameObject.transform.localRotation = Quaternion.Euler(0,90,0));
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
                ToolsAmount++;
            });
        }

        public void RemoveOne()
        {
            tools.Pop();
            ToolsAmount--;
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