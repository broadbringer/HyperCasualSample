using DG.Tweening;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Animations
{
    public class RocketFadeUp : MonoBehaviour
    {
        public Transform Rocket;
        public float AnimationTime = 1f;
        public Vector3 EndScale = new (1, 1, 0.8f);

        public Sequence Execute()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(Rocket.transform.DOScale(EndScale, AnimationTime));
            return sequence;
        } 
    }
}