using Packages.HyperCasualSample.Scripts.Services;

namespace Packages.HyperCasualSample.Scripts.Providers
{
    public class ConfigProvider : IService
    {
        public void RegisterSingle<TConfig>(TConfig implementation) where TConfig : IConfig => 
            Implementation<TConfig>.ServiceInstance = implementation;

        public TConfig Single<TConfig>() where TConfig : IConfig =>
            Implementation<TConfig>.ServiceInstance;

        private static class Implementation<TConfig> where TConfig : IConfig
        {
            public static TConfig ServiceInstance;
        }
    }
}