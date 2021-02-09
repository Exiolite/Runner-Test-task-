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

        private List<int> _strengthForFood = new List<int>();


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
            for (var foodStraightLines = 1; foodStraightLines <= BarricadesOnLevel; foodStraightLines++)
            {
                var randomLine = Random.Range(0, 4);
                var offsetZ = (foodStraightLines * 30) - Random.Range(15,20);
                
                for (var amountOfFoods = 0; amountOfFoods <= AmountOfFoodsInLine; amountOfFoods++)
                {
                    var food = _levelManager.DataBase.TryGetRandomFood(out var success);
                    if (success)
                    {
                        var foodPosition = new Vector3(randomLine, food.transform.position.y, amountOfFoods + offsetZ);
                        
                        var spawnedFood = _levelManager.Factory.SpawnFoodAtPosition(food, foodPosition);
                        spawnedFood.SetFoodStrength(_strengthForFood[foodStraightLines-1] / AmountOfFoodsInLine);
                    }
                }
            }
        }
        
        private void CreateObstacles()
        {
            for (var obstacleBarricade = 0; obstacleBarricade < BarricadesOnLevel; obstacleBarricade++)
            {
                int minStrengthForLine = 10000;
                for (var posX = 0; posX < 4; posX++)
                {
                    var obstacle = _levelManager.DataBase.TryGetObstacle(out var success);
                    if (success)
                    {
                        var obstaclePosition = new Vector3(posX, obstacle.transform.position.y, obstacleBarricade * ObstaclesRange + OffsetZ);
                        var spawnedObstacle = _levelManager.Factory.SpawnOstacleAtPosition(obstacle, obstaclePosition);
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
            return Random.Range(150, 1500);
        }
    }
}