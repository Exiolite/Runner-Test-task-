using UnityEngine;

namespace Core.LevelManagement
{
    public class Factory : MonoBehaviour
    {
        public void SpawnObjectAtPosition(GameObject target, Vector3 targetPosition)
        {
            var spawnedObject = Instantiate(target);
            spawnedObject.transform.position = targetPosition;
        }

        public void SpawnObject(GameObject target)
        {
            Instantiate(target);
        }
    }
}