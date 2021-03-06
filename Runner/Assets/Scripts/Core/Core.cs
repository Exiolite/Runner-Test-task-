﻿using Core.LevelManagement;
using Events;
using UnityEngine;

namespace Core
{
    public class Core : MonoBehaviour
    {
        #region Singleton

        private static Core _instance;
        public static Core Instance => _instance;

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            FirstInitialization();
        }

        #endregion


        [SerializeField] private bool disableLevelCreation;

        private readonly LevelManager _levelManager = new LevelManager();
        private Factory _factory;


        private void FirstInitialization()
        {
            gameObject.AddComponent<GameInput>();
            AddFactory();
            LevelManagerInitialization();
            if (disableLevelCreation == false)
            {
                GenerateLevel();
            }
        }

        private void AddFactory()
        {
            _factory = gameObject.AddComponent<Factory>();
        }

        private void LevelManagerInitialization()
        {
            _levelManager.InitializeFactory(_factory);
            _levelManager.Initialize();
            LevelEvent.RecreateLevel.AddListener(_levelManager.RecreateLevel);
        }

        private void GenerateLevel()
        {
            _levelManager.CreateLevel();
        }
    }
}