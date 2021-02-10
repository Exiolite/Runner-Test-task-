using Core;
using Events;
using Modules;
using UnityEngine;

namespace Objects
{
    public class Player : ObjectBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private PlayerCharacterHeightRegulator playerCharacterHeightRegulator;

        private readonly Strength _strength = new Strength();
        private bool _isPlayerPushingObstacle;

        private bool _disableUpdate;


        protected override void Initialization()
        {
            _disableUpdate = false;
            movement.Initialize(transform);
        }

        protected override void OnStart()
        {
            LevelEvent.SetPlayer.Invoke(this);
            ObstacleEvent.PlayerWinsObstacle.AddListener(PlayerWinsObstacle);
            GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
            FoodEvent.AddStrength.AddListener(AddStrength);
            LevelEvent.PlayerWins.AddListener(DisableExecute);
            InputEvent.HorizontalSwipe.AddListener(Swipe);
            CameraEvent.SetPlayerAsTarget.Invoke(transform);
        }

        protected override void Execute()
        {
            if (_disableUpdate) return;
            if (_isPlayerPushingObstacle)
            {
                GuiEvent.UpdateStrengthCounter.Invoke(_strength.GetRoundedStrength());
                movement.MoveWithObstacleSpeed();
                _strength.TryRemoveStrength(out var success);
                playerCharacterHeightRegulator.SetRobotsHeight(_strength.GetRoundedStrength());
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
            InputEvent.HorizontalSwipe.RemoveListener(Swipe);
            CameraEvent.ResetTarget.Invoke();
        }


        private void Swipe(bool direction)
        {
            if (_isPlayerPushingObstacle) return;
            movement.ChangeLine(direction);
        }

        private void AddStrength(float value)
        {
            playerCharacterHeightRegulator.SetRobotsHeight(_strength.GetRoundedStrength());
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
            _disableUpdate = true;
        }
    }
}