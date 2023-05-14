using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Animations
{
    public class HeroAnimator : MonoBehaviour
    {
        private readonly int IsMoving = Animator.StringToHash("IsMoving");
        private readonly int IsWithBox = Animator.StringToHash("IsWithBox");
        
        public Animator AnimatorInstance;

        public void SetMoving(bool @as) => 
            AnimatorInstance.SetBool(IsMoving, @as);

        public void SetWithBox(bool @as) => 
            AnimatorInstance.SetBool(IsWithBox, @as);
    }
}