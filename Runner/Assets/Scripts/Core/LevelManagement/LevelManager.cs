using Objects;

namespace Core.LevelManagement
{
    public class LevelManager
    {
        // Core Modules.
        public ObjectsDataBase DataBase { get; } = new ObjectsDataBase();
        public Factory Factory { get; private set; }
        
        private bool _isFactoryInitialized;

        private readonly LevelCreator _levelCreator = new LevelCreator();
        



        public void InitializeFactory(Factory factory)
        {
            Factory = factory;
            _isFactoryInitialized = true;
        }

        public void Initialize()
        {
            DataBase.LoadResources();
            _levelCreator.Initialize(this);
        }

        public void GenerateLevel()
        {
            if (CheckInitialization())
            {
                _levelCreator.CreateLevel();
            }
        }
        
        

        private bool CheckInitialization()
        {
            if (_isFactoryInitialized)
            {
                return _isFactoryInitialized;
            }
            throw new System.Exception("Factory isn't initialized in level manager");
        }
    }
}