using System;
using System.Collections;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Animations
{
    public class RocketFadeUp : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3);
            
        }
    }
}