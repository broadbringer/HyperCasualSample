using System;
using Packages.HyperCasualSample.Scripts.Kernel;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
   private SceneLoader _sceneLoader;
   private string _gameplaySceneName;
   private InputService _inputService;
   
   private void Awake()
   {
      ServiceLocator.Instance.RegisterSingle(new SceneLoader());
      ServiceLocator.Instance.RegisterSingle(new InputService());
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