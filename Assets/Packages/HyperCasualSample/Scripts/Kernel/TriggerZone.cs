using System;
using System.Collections;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Kernel
{
    public class TriggerZone : MonoBehaviour
    {
        public float Delay;

        public bool isWorking;
        private Action _triggerEnterAction;
        private Action _triggerStayAction;
        private Action _triggerExitAction;

        public void Construct(Action triggerEnterAction = null, Action triggerStayAction = null,
            Action triggerExitAction = null)
        {
            _triggerEnterAction = triggerEnterAction;
            _triggerStayAction = triggerStayAction;
            _triggerExitAction = triggerExitAction;
        }

        public void OnCollisionEnter(Collision other) =>
            _triggerEnterAction?.Invoke();

        public void OnCollisionStay(Collision other)
        {
            if(isWorking)
                return;
            StartCoroutine(RunWithDelay());

        }

        private IEnumerator RunWithDelay()
        {
            isWorking = true;
            yield return new WaitForSeconds(0.1f);
            _triggerStayAction?.Invoke();
            isWorking = false;
        }

        public void OnCollisionExit(Collision other)
        {
            _triggerExitAction?.Invoke();
        }
    }
}