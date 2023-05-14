using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Kernel
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;

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
            }
            
            CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}