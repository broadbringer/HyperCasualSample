using Packages.HyperCasualSample.Scripts.Kernel;

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