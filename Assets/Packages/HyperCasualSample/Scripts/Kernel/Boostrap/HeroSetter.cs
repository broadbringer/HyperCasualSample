using Packages.HyperCasualSample.Scripts.MainHero;
using Packages.HyperCasualSample.Scripts.Providers;
using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Kernel.Boostrap
{
    public class HeroSetter : MonoBehaviour
    {
        public Hero HeroInstance;

        private void Start() => 
            ServiceLocator.Instance.Single<HeroProvider>().SetHero(HeroInstance);
    }
}