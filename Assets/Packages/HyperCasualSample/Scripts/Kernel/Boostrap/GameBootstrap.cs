using System;
using Packages.HyperCasualSample.Scripts.Data;
using Packages.HyperCasualSample.Scripts.Kernel;
using Packages.HyperCasualSample.Scripts.Services;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
   private SceneLoader _sceneLoader;
   private string _gameplaySceneName;
   private InputService _inputService;

   public LevelConfig LevelConfig;
   
   private void Awake()
   {
      
      ServiceLocator.Instance.RegisterSingle(new SceneLoader());
      ServiceLocator.Instance.RegisterSingle(new InputService());
      ServiceLocator.Instance.RegisterSingle(new ConfigProvider());

      var configProvider = ServiceLocator.Instance.Single<ConfigProvider>();
      configProvider.RegisterSingle(LevelConfig);
      
      _sceneLoader = ServiceLocator.Instance.Single<SceneLoader>();
      _inputService = ServiceLocator.Instance.Single<InputService>();
   }

   private void Start()
   {
      
      //_sceneLoader.LoadWith(_gameplaySceneName);
   }

   private void Update()
   {
      Debug.Log(_inputService.Axis);
   }
}

public class InputService : IService
{
   private const string Horizontal = "Horizontal";
   private const string Vertical = "Vertical";
   public Vector2 Axis => new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
}