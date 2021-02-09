using Core.LevelManagement;
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

        private readonly LevelManager _levelManager = new LevelManager();
        
        private Factory _factory;
        
        
        
        private void FirstInitialization()
        {
            AddFactory();
            ModulesInitialization();
        }

        private void AddFactory()
        {
            _factory = gameObject.AddComponent<Factory>();
        }

        private void ModulesInitialization()
        {
            _levelManager.InitializeFactory(_factory);
            _levelManager.Initialize();
        }

        private void GenerateLevel()
        {
            _levelManager.GenerateLevel();
        }
    }
}
