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

        public void OnTriggerEnter(Collider other) => 
            _triggerEnterAction?.Invoke();

        public void OnTriggerStay(Collider other) => 
            _triggerStayAction?.Invoke();

        public void OnTriggerExit(Collider other) => 
            _triggerExitAction?.Invoke();
    }
}