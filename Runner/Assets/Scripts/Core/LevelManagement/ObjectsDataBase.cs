using Objects;
using Objects.Obstacles;
using UnityEngine;

namespace Core.LevelManagement
{
    public class ObjectsDataBase
    {
        private Obstacle _obstacle;
        private Player _player;



        public void LoadResources()
        {
            _obstacle = Resources.Load<Obstacle>("Resources/Prefabs/Obstacles/Obstacle");
            _player = Resources.Load<Player>("Resources/Prefabs/Player/Player");
        }

        public Obstacle TryGetObstacle(out bool success)
        {
            if (_obstacle != null)
            {
                success = true;
                return _obstacle;
            }

            success = false;
            throw new System.Exception("Obstacle isn't loaded in DataBase");
        }
        
        public Player TryGetPlayer(out bool success)
        {
            if (_player != null)
            {
                success = true;
                return _player;
            }

            success = false;
            throw new System.Exception("Player isn't loaded in DataBase");
        }
    }
}