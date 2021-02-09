using System.Globalization;
using Core;
using Events;
using TMPro;
using UnityEngine;

namespace Objects
{
    public class Gui : ObjectBehaviour
    {
        [SerializeField] private TextMeshProUGUI playersStrengthCounter;

        private float _playersStrength;

        

        protected override void Initialization(){}

        protected override void OnStart()
        {
            GuiEvent.UpdateStrengthCounter.AddListener(SetStrength);
        }

        protected override void Execute(){}
        protected override void BeforeDestroy(){}


        private void SetStrength(float strength)
        {
            playersStrengthCounter.text = strength.ToString(CultureInfo.InvariantCulture);
        }
    }
}