using System;
using Packages.HyperCasualSample.Scripts.Kernel;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
   private SceneLoader _sceneLoader;
   private string _gameplaySceneName;
   
   private void Awake()
   {
      ServiceLocator.Instance.RegisterSingle(new SceneLoader());
      _sceneLoader = ServiceLocator.Instance.Single<SceneLoader>();
   }

   private void Start()
   {
      _sceneLoader.LoadWith(_gameplaySceneName);
   } 
}