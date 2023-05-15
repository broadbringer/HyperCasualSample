using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Packages.HyperCasualSample.Scripts.Animations;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class RocketMachineAnimation : MonoBehaviour
    {
        public RocketFadeUp RocketFadeUp;
        public Transform Press;

        public float PressTimeAnimation;
        public Vector3 PressStartPosition;
        public Vector3 PressEndPosition;
        
        public async UniTask PlayPressAnimation()
        {
            var sequance = DOTween.Sequence();
            sequance.Append(Press.DOLocalMoveY(PressEndPosition.y, PressTimeAnimation / 2));
            sequance.Append(Press.DOLocalMoveY(PressStartPosition.y, PressTimeAnimation / 2));
            sequance.Append(RocketFadeUp.Execute());
            await UniTask.Delay(TimeSpan.FromSeconds(PressTimeAnimation + 3.4f));
        }
    }
}