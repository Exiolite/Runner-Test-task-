using System.Globalization;
using Core;
using Core.LevelManagement;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public class Gui : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playersStrengthCounter;
        [SerializeField] private Button resetButton;

        private float _playersStrength;



        public void RecreateLevel()
        {
            LevelEvent.RecreateLevel.Invoke();
            LevelEvent.DestroyAllObjects.Invoke();
            resetButton.gameObject.SetActive(false);
        }
        
        

        private void Start()
        {
            GuiEvent.UpdateStrengthCounter.AddListener(SetStrength);
            LevelEvent.PlayerWins.AddListener(ShowResetButton);
            LevelEvent.PlayerLose.AddListener(ShowResetButton);

            resetButton.gameObject.SetActive(false);
        }

        private void HideResetButton()
        {
            resetButton.gameObject.SetActive(false);
        }
        
        private void ShowResetButton()
        {
            resetButton.gameObject.SetActive(true);
        }
        
        private void SetStrength(float strength)
        {
            playersStrengthCounter.text = strength.ToString(CultureInfo.InvariantCulture);
        }
    }
}