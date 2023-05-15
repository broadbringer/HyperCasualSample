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
            sequence.Append(MoveAndRotate());
            return sequence;
        }

        public Sequence MoveAndRotate()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(Rocket.transform.DOLocalMoveX(1.82f, 3));

            var sequenceTwo = DOTween.Sequence();
            
            sequenceTwo.Append((Rocket.DOLocalRotate(new Vector3(-90, 0, 0), 1f)));
            sequenceTwo.Join(Rocket.DOScale(Vector3.zero, 1f));
                sequence.Append(sequenceTwo);
            return sequence;
        }
    }
}