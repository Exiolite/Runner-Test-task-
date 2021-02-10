using Core;
using Events;
using UnityEngine;

namespace Objects
{
    public class Road : ObjectBehaviour
    {
        protected override void Initialization(){}
        protected override void OnStart(){}
        protected override void Execute(){}
        protected override void BeforeDestroy(){}


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                LevelEvent.PlayerWins.Invoke();
            }
        }
    }
}