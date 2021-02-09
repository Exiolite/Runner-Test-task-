using UnityEngine;

namespace Modules
{
    [System.Serializable]
    public class Movement
    {
        [SerializeField] private float playerSpeed = 4;
        [SerializeField] private float obstacleSpeed = 1;

        private Transform _parentTransform;
        private bool _isInitialized;

        private int _maxLeftLine = 0;
        private int _maxRightLine = 3;



        public void Initialize(Transform parentTransform)
        {
            _parentTransform = parentTransform;
            _isInitialized = true;
        }
        
        
        
        public void MoveWithPlayerSpeed()
        {
            CheckInitialization();
            MoveForwardWithDeltaSpeed(playerSpeed);
        }

        public void MoveWithObstacleSpeed()
        {
            CheckInitialization();
            MoveForwardWithDeltaSpeed(obstacleSpeed);
        }

        //True == right, False == left.
        public void ChangeLine(bool swipeDirection)
        {
            int clampedPosX;
            if (swipeDirection)
            {
                clampedPosX = Mathf.Clamp((int)_parentTransform.position.x + 1, _maxLeftLine, _maxRightLine);
            }
            else
            {
                clampedPosX = Mathf.Clamp((int)_parentTransform.position.x - 1, _maxLeftLine, _maxRightLine);
            }
            _parentTransform.position = new Vector3(clampedPosX, _parentTransform.position.y, _parentTransform.position.z);
        }

        

        private void MoveForwardWithDeltaSpeed(float speed)
        {
            var deltaSpeed = Time.deltaTime * speed;
            _parentTransform.position += _parentTransform.forward * deltaSpeed;
        }
        
        private bool CheckInitialization()
        {
            if (_isInitialized)
            {
                return _isInitialized;
            }
            throw new System.Exception("Module Movement isn't initialized");
        }
    }
}