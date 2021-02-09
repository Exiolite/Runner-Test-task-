using UnityEngine;

namespace Core.LevelManagement
{
    public class LevelCreator
    {
        private LevelManager _levelManager;
        
        private const int LevelLength = 4;
        private const int ObstaclesRange = 30;
        private const int OffsetZ = 30;

        
        
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
            var player = _levelManager.DataBase.TryGetPlayer(out var success);
            if (success)
            {
                _levelManager.Factory.SpawnObject(player.gameObject);
            }
        }

        private void CreateRoad()
        {
            
        }

        private void CreateFood()
        {
            
        }
        
        private void CreateObstacles()
        {

            for (var length = 0; length < LevelLength; length++)
            {
                for (var posX = 0; posX <= 4; posX++)
                {
                    var obstacle = _levelManager.DataBase.TryGetObstacle(out var success);
                    if (success)
                    {
                        var obstaclePosition = new Vector3(posX, obstacle.transform.position.y, length * ObstaclesRange + OffsetZ);
                        _levelManager.Factory.SpawnObjectAtPosition(obstacle.gameObject, obstaclePosition);
                    }
                }
            }
        }
    }
}