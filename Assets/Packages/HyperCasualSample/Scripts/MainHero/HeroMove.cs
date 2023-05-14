using Packages.HyperCasualSample.Scripts.Kernel.Boostrap;
using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.MainHero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;
        public Hero Hero;
        
        private InputService _inputService;
        private Camera _camera;
        
        private void Start()
        {
            _inputService = ServiceLocator.Instance.Single<InputService>();
            _camera = Camera.main;
        } 

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
                Hero.Animator.SetMoving(true);
            }
            else
            {
                Hero.Animator.SetMoving(false);
            }
            
            CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}