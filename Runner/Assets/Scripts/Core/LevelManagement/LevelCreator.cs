using System.Collections.Generic;
using UnityEngine;

namespace Core.LevelManagement
{
    public class LevelCreator
    {
        private LevelManager _levelManager;

        private const int BarricadesOnLevel = 4;
        private const int AmountOfFoodsInLine = 5;
        private const int ObstaclesRange = 30;
        private const int OffsetZ = 30;

        private readonly List<int> _strengthForFood = new List<int>();


        public void Initialize(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void CreateLevel()
        {
            CreatePlayer();
            CreateObstacles();
            CreateFood();
            CreateRoad();
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
            var road = _levelManager.DataBase.TryGetRandomRoad(out var success);
            if (success)
            {
                _levelManager.Factory.SpawnObject(road.gameObject);
            }
        }

        private void CreateFood()
        {
            for (var foodLine = 1; foodLine <= BarricadesOnLevel; foodLine++)
            {
                var randomLine = Random.Range(0, 4);
                var lineOffsetZ = (foodLine * 30) - Random.Range(15, 20);

                for (var foodsInLine = 0; foodsInLine <= AmountOfFoodsInLine; foodsInLine++)
                {
                    var food = _levelManager.DataBase.TryGetRandomFood(out var success);
                    if (success)
                    {
                        var foodPosition = new Vector3(randomLine, food.transform.position.y,
                            foodsInLine + lineOffsetZ);

                        var spawnedFood = _levelManager.Factory.SpawnFoodAtPosition(food, foodPosition);
                        var foodStrength = _strengthForFood[foodLine - 1] / AmountOfFoodsInLine + 1;
                        spawnedFood.SetFoodStrength(foodStrength);
                    }
                }
            }
        }

        private void CreateObstacles()
        {
            _strengthForFood.Clear();
            for (var obstacleBarricade = 0; obstacleBarricade < BarricadesOnLevel; obstacleBarricade++)
            {
                var minStrengthForLine = 1000;
                for (var posX = 0; posX < 4; posX++)
                {
                    var obstacle = _levelManager.DataBase.TryGetRandomObstacle(out var success);
                    if (success)
                    {
                        var obstaclePosition = new Vector3(posX, obstacle.transform.position.y,
                            obstacleBarricade * ObstaclesRange + OffsetZ);
                        var spawnedObstacle = _levelManager.Factory.SpawnObstacleAtPosition(obstacle, obstaclePosition);
                        var strengthForObstacle = GenerateRandomStrength();

                        if (strengthForObstacle < minStrengthForLine)
                        {
                            minStrengthForLine = strengthForObstacle;
                        }

                        spawnedObstacle.SetObstacle(strengthForObstacle);
                    }
                }

                _strengthForFood.Add(minStrengthForLine);
            }
        }

        private int GenerateRandomStrength()
        {
            return Random.Range(150, 1000);
        }
    }
}