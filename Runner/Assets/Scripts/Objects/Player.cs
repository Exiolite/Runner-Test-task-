using Core;
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

        private bool _disableInput;
        
        
        
        protected override void Initialization()
        {
            _disableInput = false;
            movement.Initialize(transform);
        }

        protected override void OnStart()
        {
            LevelEvent.SetPlayer.Invoke(this);
            ObstacleEvent.PlayerWinsObstacle.AddListener(PlayerWinsObstacle);
            CameraEvent.SetPlayerAsTarget.Invoke(transform);
            GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
            FoodEvent.AddStrength.AddListener(AddStrength);
            LevelEvent.PlayerWins.AddListener(DisableExecute);
        }

        protected override void Execute()
        {
            if (_disableInput) return;
            // For debug
            if (_isPlayerPushingObstacle == false)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    movement.ChangeLine(false);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movement.ChangeLine(true);
                }
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
            LevelEvent.PlayerWins.RemoveListener(DisableExecute);
            LevelEvent.ResetPlayer.Invoke();
            CameraEvent.ResetTarget.Invoke();
            ObstacleEvent.PlayerWinsObstacle.RemoveListener(PlayerWinsObstacle);
        }

        
        
        private void AddStrength(float value)
        {
            _strength.AddStrength(value);
            GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _isPlayerPushingObstacle = true;
            }
        }

        private void PlayerWinsObstacle()
        {
            _isPlayerPushingObstacle = false;
        }

        private void DisableExecute()
        {
            _disableInput = true;
        }
    }
}