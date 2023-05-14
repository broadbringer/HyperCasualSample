using Packages.HyperCasualSample.Scripts.MainHero;
using Packages.HyperCasualSample.Scripts.Services;

namespace Packages.HyperCasualSample.Scripts.Providers
{
    public class HeroProvider : IService
    {
        private Hero _hero;

        public Hero Hero=> _hero;
    
        public void SetHero(Hero hero)
        {
            if(_hero)
                return;

            _hero = hero;
        }
    }
}