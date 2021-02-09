namespace Core.LevelManagement
{
    public class LevelGenerator
    {
        private LevelManager _levelManager;

        public void Initialize(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void CreateLevel()
        {
            CreateRoad();
            CreatePlayer();
            CreateFood();
            CreateObstacles();
        }



        private void CreatePlayer()
        {
            
        }

        private void CreateRoad()
        {
            
        }

        private void CreateFood()
        {
            
        }
        
        private void CreateObstacles()
        {
            
        }
    }
}