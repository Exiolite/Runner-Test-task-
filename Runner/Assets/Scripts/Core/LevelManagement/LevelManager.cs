namespace Core.LevelManagement
{
    public class LevelManager
    {
        public ObjectsDataBase DataBase { get; } = new ObjectsDataBase();
        public Factory Factory { get; private set; }


        private readonly LevelCreator _levelCreator = new LevelCreator();

        private bool _isFactoryInitialized;


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

        public void CreateLevel()
        {
            if (CheckInitialization())
            {
                _levelCreator.CreateLevel();
            }
        }

        public void RecreateLevel()
        {
            CreateLevel();
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