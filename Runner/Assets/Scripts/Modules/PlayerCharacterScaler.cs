using UnityEngine;

namespace Modules
{
    [System.Serializable]
    public class PlayerCharacterScaler
    {
        [SerializeField] private GameObject topPeace;
        [SerializeField] private GameObject midPeace;

        private const float MaxHeight = 1.0f;



        public void SetScale(float strength)
        {
            var topPeacePosition = topPeace.transform.localPosition;
            var midPeacePosition = midPeace.transform.localPosition;
            
            var topPositionY = strength/1500;
            var midPositionY = strength/1500/2;

            topPeace.transform.localPosition = new Vector3( topPeacePosition.x, topPositionY, topPeacePosition.z);
            midPeace.transform.localPosition = new Vector3( midPeacePosition.x, midPositionY, midPeacePosition.z);
        }
    }
}