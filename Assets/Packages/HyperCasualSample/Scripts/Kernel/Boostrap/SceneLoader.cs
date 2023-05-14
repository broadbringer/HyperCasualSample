using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine.SceneManagement;

namespace Packages.HyperCasualSample.Scripts.Kernel.Boostrap
{
    public class SceneLoader : IService
    {
        public void LoadWith(string gameplaySceneName) => 
            SceneManager.LoadScene(gameplaySceneName);
    }
}