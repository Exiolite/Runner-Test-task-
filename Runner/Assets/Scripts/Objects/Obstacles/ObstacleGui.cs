using System.Globalization;
using Core;
using Modules;
using TMPro;
using UnityEngine;

namespace Objects.Obstacles
{
    public class ObstacleGui : ObjectBehaviour
    {
        [SerializeField] private TextMeshProUGUI obstacleStrengthCounter;

        private Strength _strength;

        
        
        public void DisplayObstacleStrength()
        {
            obstacleStrengthCounter.text = _strength.GetRoundedStrength().ToString(CultureInfo.InvariantCulture);
        }
        
        
        
        protected override void Initialization()
        {
            _strength = GetComponentInParent<Obstacle>().Strength;
        }

        protected override void OnStart()
        {
            DisplayObstacleStrength();
        }
        protected override void Execute(){}
    }
}