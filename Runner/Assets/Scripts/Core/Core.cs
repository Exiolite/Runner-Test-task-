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


        public LevelManager LevelManager { get; } = new LevelManager();
        
        [SerializeField] private bool disableLevelCreation;

        private Factory _factory;
        
        
        
        private void FirstInitialization()
        {
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
            LevelManager.InitializeFactory(_factory);
            LevelManager.Initialize();
        }

        private void GenerateLevel()
        {
            LevelManager.GenerateLevel();
        }
    }
}
