using Objects;
using Objects.Obstacles;
using UnityEngine;

namespace Core.LevelManagement
{
    public class ObjectsDataBase
    {
        private Obstacle _obstacle;
        private Player _player;

        private Food[] _foods;
        private Road[] _roads;


        public void LoadResources()
        {
            _obstacle = Resources.Load<Obstacle>("Prefabs/Obstacles/Obstacle");
            _player = Resources.Load<Player>("Prefabs/Player/Player");

            _foods = Resources.LoadAll<Food>("Prefabs/Foods");
            _roads = Resources.LoadAll<Road>("Prefabs/Roads");
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

        public Food TryGetRandomFood(out bool success)
        {
            if (_foods.Length == 0)
            {
                success = false;
                throw new System.Exception("Food isn't loaded in DataBase");
            }

            var food = _foods[Random.Range(0, _foods.Length)];
            success = true;
            return food;
        }
        
        public Road TryGetRandomRoad(out bool success)
        {
            if (_roads.Length == 0)
            {
                success = false;
                throw new System.Exception("Food isn't loaded in DataBase");
            }

            var road = _roads[Random.Range(0, _roads.Length)];
            success = true;
            return road;
        }
    }
}