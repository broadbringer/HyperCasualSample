using Packages.HyperCasualSample.Scripts.Kernel;
using UnityEngine.SceneManagement;

public class SceneLoader : IService
{
    public void LoadWith(string gameplaySceneName) => 
        SceneManager.LoadScene(gameplaySceneName);
}