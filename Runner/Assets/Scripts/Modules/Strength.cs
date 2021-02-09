using UnityEngine;

namespace Modules
{
    public class Strength
    {
        private const float StrengthRemovingValue = 150;
        
        private float _strength;



        public float GetRoundedStrength()
        {
            return Mathf.Round(_strength);
        }
        
        public void SetStrength(float value)
        {
            _strength = value;
        }

        public void AddStrength(float value)
        {
            _strength += value;
        }
        
        public void TryRemoveStrength(out bool success)
        {
            if (_strength > 0)
            {
                var deltaRemovingValue = StrengthRemovingValue * Time.deltaTime;
                var obstacleValue = Mathf.Clamp(_strength - deltaRemovingValue, 0, _strength);
                _strength = obstacleValue;
                success = true;
            }
            else
            {
                success = false;
            }
        }
    }
}