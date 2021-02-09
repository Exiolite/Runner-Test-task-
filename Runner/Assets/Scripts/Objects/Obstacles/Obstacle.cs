using Core;
using Events;
using Modules;
using UnityEngine;

namespace Objects.Obstacles
{
    public class Obstacle : ObjectBehaviour
    {
        public Strength Strength => _strength;
        
        
        [SerializeField] private Movement movement;
        [SerializeField] private ObstacleGui obstacleGui;
        
        
        private readonly Strength _strength = new Strength();
        private bool _isPlayerMovingObstacle;

        

        public void SetObstacle(int obstacleStrength)
        {
            _strength.SetStrength(obstacleStrength);
        }
        

        
        protected override void Initialization()
        {
            movement.Initialize(transform);
            SetObstacle(150);
        }
        
        protected override void OnStart()
        {
            ObstacleEvent.PlayerMoveObstacle.AddListener(PlayerMoveObstacle);
            LevelEvent.PlayerLose.AddListener(StopAllActions);
        }

        protected override void Execute()
        {
            if (_isPlayerMovingObstacle)
            {
                movement.MoveWithObstacleSpeed();

                obstacleGui.DisplayObstacleStrength();
                
                _strength.TryRemoveStrength(out var success);
                if (success == false)
                {
                    DestroyItSelf();
                }
            }
        }

        protected override void BeforeDestroy()
        {
            ObstacleEvent.PlayerWinsObstacle.Invoke();
            ObstacleEvent.PlayerMoveObstacle.RemoveListener(PlayerMoveObstacle);
        }



        private void StopAllActions()
        {
            _isPlayerMovingObstacle = false;
        }
        
        private void PlayerMoveObstacle(GameObject targetObstacle)
        {
            if (gameObject != targetObstacle) return;
            
            if (_isPlayerMovingObstacle == false)
            {
                _isPlayerMovingObstacle = true;
            }
        }
    }
}