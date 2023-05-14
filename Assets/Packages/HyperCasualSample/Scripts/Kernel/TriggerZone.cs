using System;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Kernel
{
    public class TriggerZone : MonoBehaviour
    {
        private Action _triggerEnterAction;
        private Action _triggerStayAction;
        private Action _triggerExitAction;

        public void Construct(Action triggerEnterAction = null, Action triggerStayAction = null, Action triggerExitAction = null)
        {
            _triggerEnterAction = triggerEnterAction;
            _triggerStayAction = triggerStayAction;
            _triggerExitAction = triggerExitAction;
        }
        
        public void OnCollisionEnter(Collision other) => 
            _triggerEnterAction?.Invoke();

        public void OnCollisionStay(Collision other) => 
            _triggerStayAction?.Invoke();

        public void OnCollisionExit(Collision other) => 
            _triggerExitAction?.Invoke();
    }
}