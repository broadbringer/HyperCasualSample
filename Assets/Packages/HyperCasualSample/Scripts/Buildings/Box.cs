using System;
using System.Collections.Generic;
using System.Linq;
using Packages.HyperCasualSample.Scripts.Kernel;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Buildings
{
    public class Box : MonoBehaviour
    {
        public TriggerZone TriggerZone;
        public BoxPlaceholder Placeholder;

        public List<Transform> Pull;
        
        private void Awake()
        {
            TriggerZone.Construct(triggerStayAction: AddOne);
        }

        private void AddOne()
        {
            var box = Pull.First(t => !t.gameObject.activeSelf);
            box.gameObject.SetActive(true);
            box.transform.localPosition = Placeholder.GetEndPosition();
        }
    }
}