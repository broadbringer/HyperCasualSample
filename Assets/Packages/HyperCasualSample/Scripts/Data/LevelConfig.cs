using Packages.HyperCasualSample.Scripts.Providers;
using UnityEngine;

namespace Packages.HyperCasualSample.Scripts.Data
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "StaticData/Config/Level", order = 0)]
    public class LevelConfig : ScriptableObject, IConfig
    {
        public int BoxPlaceholderMaxAmount = 10;
        public int FactoryPlaceholderMaxAmount = 10;
        public int HeroPlaceholderMaxAmount = 10;
    }
}