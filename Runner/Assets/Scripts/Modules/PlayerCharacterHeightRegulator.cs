using UnityEngine;

namespace Modules
{
    [System.Serializable]
    public class PlayerCharacterHeightRegulator
    {
        [SerializeField] private GameObject topPeace;
        [SerializeField] private GameObject midPeace;

        private const float MaxHeight = 1000.0f;


        public void SetRobotsHeight(float strength)
        {
            var topPeacePosition = topPeace.transform.localPosition;
            var midPeacePosition = midPeace.transform.localPosition;

            var topPositionY = strength / MaxHeight;
            var midPositionY = strength / MaxHeight / 2;

            topPeace.transform.localPosition = new Vector3(topPeacePosition.x, topPositionY, topPeacePosition.z);
            midPeace.transform.localPosition = new Vector3(midPeacePosition.x, midPositionY, midPeacePosition.z);
        }
    }
}