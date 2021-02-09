using Core;
using Events;
using Modules;
using UnityEngine;

namespace Objects
{
    public class Player : ObjectBehaviour
    {
        [SerializeField] private Movement movement;

        private Strength _strength;
        private bool _isPlayerPushingObstacle;
        
        
        
        protected override void Initialization()
        {
            movement.Initialize(transform);
        }

        protected override void OnStart()
        {
            ObstacleEvent.PlayerWinsObstacle.AddListener(PlayerWinsObstacle);
            CameraEvent.SetPlayerAsTarget.Invoke(transform);
        }

        protected override void Execute()
        {
            // For debug
            if (Input.GetKeyDown(KeyCode.A))
            {
                movement.ChangeLine(false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                movement.ChangeLine(true);
            }
            
            
            
            if (_isPlayerPushingObstacle)
            {
                movement.MoveWithObstacleSpeed();
            }
            else
            {
                movement.MoveWithPlayerSpeed();
            }
        }

        

        private void OnCollisionEnter(Collision other)
        {
            ObstacleEvent.PlayerMoveObstacle.Invoke(other.gameObject);
            _isPlayerPushingObstacle = true;
        }

        private void PlayerWinsObstacle()
        {
            _isPlayerPushingObstacle = false;
        }

        private void DestroyItSelf()
        {
            CameraEvent.ResetTarget.Invoke();
            ObstacleEvent.PlayerWinsObstacle.RemoveListener(PlayerWinsObstacle);
        }
    }
}