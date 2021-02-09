using Core;
using Core.LevelManagement;
using Events;
using Modules;
using UnityEngine;

namespace Objects
{
    public class Player : ObjectBehaviour
    {
        [SerializeField] private Movement movement;

        private readonly Strength _strength = new Strength();
        private bool _isPlayerPushingObstacle;

        
        
        protected override void Initialization()
        {
            movement.Initialize(transform);
        }

        protected override void OnStart()
        {
            LevelEvent.SetPlayer.Invoke(this);
            
            ObstacleEvent.PlayerWinsObstacle.AddListener(PlayerWinsObstacle);
            
            CameraEvent.SetPlayerAsTarget.Invoke(transform);
            
            GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
            
            FoodEvent.AddStrength.AddListener(AddStrength);
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
                GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
                movement.MoveWithObstacleSpeed();
                _strength.TryRemoveStrength(out var success);
                if (success == false)
                {
                    LevelEvent.PlayerLose.Invoke();
                    DestroyItSelf();
                }
            }
            else
            {
                movement.MoveWithPlayerSpeed();
            }
        }

        protected override void BeforeDestroy()
        {
            LevelEvent.ResetPlayer.Invoke();
            CameraEvent.ResetTarget.Invoke();
            ObstacleEvent.PlayerWinsObstacle.RemoveListener(PlayerWinsObstacle);
        }

        
        
        private void AddStrength(float value)
        {
            _strength.AddStrength(value);
            GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                ObstacleEvent.PlayerMoveObstacle.Invoke(other.gameObject);
                _isPlayerPushingObstacle = true;
            }
        }

        private void PlayerWinsObstacle()
        {
            _isPlayerPushingObstacle = false;
        }
    }
}