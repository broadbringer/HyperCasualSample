using System;
using Packages.HyperCasualSample.Scripts.Kernel;
using Packages.HyperCasualSample.Scripts.MainHero;
using Packages.HyperCasualSample.Scripts.Providers;
using Packages.HyperCasualSample.Scripts.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Tools
{
    public class ToolsTriggerZone : MonoBehaviour
    {
        public TriggerZone TriggerZone;

        public ToolsPack ToolsPack;
        private Hero _hero;

        private void Start() =>
            TriggerZone.Construct(triggerStayAction: GiveToolsToHero);

        private void GiveToolsToHero()
        {
            if (!_hero)
                _hero = ServiceLocator.Instance.Single<HeroProvider>().Hero;

            if (ToolsPack.Tools.Count > 0)
                _hero.AddBoxes(ToolsPack.Tools.Pop());
        }
    }
}