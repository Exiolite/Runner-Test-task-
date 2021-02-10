using Objects;
using Objects.Obstacles;
using UnityEngine;

namespace Core.LevelManagement
{
    public class ObjectsDataBase
    {
        private Obstacle[] _obstacles;
        private Player _player;
        private Food[] _foods;
        private Road[] _roads;


        public void LoadResources()
        {
            _obstacles = Resources.LoadAll<Obstacle>("Prefabs/Obstacles");
            _player = Resources.Load<Player>("Prefabs/Player/Player");

            _foods = Resources.LoadAll<Food>("Prefabs/PowerUps");
            _roads = Resources.LoadAll<Road>("Prefabs/Roads");
        }


        public Obstacle TryGetRandomObstacle(out bool success)
        {
            if (_obstacles.Length == 0)
            {
                success = false;
                throw new System.Exception("Obstacle isn't loaded in DataBase");
            }

            var obstacle = _obstacles[Random.Range(0, _obstacles.Length)];
            success = true;
            return obstacle;
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