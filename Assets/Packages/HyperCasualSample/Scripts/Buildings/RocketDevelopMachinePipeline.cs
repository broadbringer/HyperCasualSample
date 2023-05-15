using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class RocketDevelopMachinePipeline : MonoBehaviour
    {
        public RocketDevelopMachine RocketDevelopMachine;
        public RocketMachineAnimation RocketMachineAnimation;
        public RocketPack RocketPack;
        public GameObject RocketPrefab;
        
        private void Start()
        {
            Execute();
        }

        private async UniTask Execute()
        {
            while (true)
            {
                await UniTask.Yield();

                if (RocketDevelopMachine.ToolsAmount > 0)
                {
                    RocketDevelopMachine.RemoveOne();
                    await RocketMachineAnimation.PlayPressAnimation();
                    RocketPack.AddOne(Instantiate(RocketPrefab, new Vector3(), Quaternion.identity).transform);
                }
            }
        }
    }
}