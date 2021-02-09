using Objects;
using Objects.Obstacles;
using UnityEngine;

namespace Core.LevelManagement
{
    public class Factory : MonoBehaviour
    {
        public Obstacle SpawnOstacleAtPosition(Obstacle target, Vector3 targetPosition)
        {
            var spawnedObject = Instantiate(target);
            spawnedObject.transform.position = targetPosition;
            return spawnedObject;
        }

        public Food SpawnFoodAtPosition(Food target, Vector3 targetPosition)
        {
            var food = Instantiate(target);
            food.gameObject.transform.position = targetPosition;
            return food;
        }
        
        public void SpawnObject(GameObject target)
        {
            Instantiate(target);
        }

    }
}