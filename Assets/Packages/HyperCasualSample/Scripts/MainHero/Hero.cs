using System.Collections.Generic;
using Packages.HyperCasualSample.Scripts.Animations;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.MainHero
{
    public class Hero : MonoBehaviour
    {
        public HeroAnimator Animator;
        public HeroBoxesPlaceholder HeroBoxesPlaceholder;
        
        private int AmountOfBoxes;

        public bool IsEmpty => AmountOfBoxes == 0;

        private Queue<Transform> boxes;
        
        private void Awake()
        {
        }

        public void AddBoxes(Transform box)
        {
            Animator.SetWithBox(true);
            HeroBoxesPlaceholder.AddOne(box);
            boxes.Enqueue(box);
            AmountOfBoxes++;
        }

        public Transform RemoveBoxes()
        {
            Animator.SetWithBox(false);
            AmountOfBoxes--;

            return boxes.Dequeue();
        }

        
    }
}