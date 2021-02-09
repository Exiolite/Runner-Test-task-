using Core;
using Events;
using UnityEngine;

namespace Objects
{
    public class Food : ObjectBehaviour
    {
        private float _foodStrength = 50;



        public void SetFoodStrength(int value)
        {
            _foodStrength = value;
        }
        
        
        
        protected override void Initialization()
        {
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void Execute()
        {
            
        }

        protected override void BeforeDestroy()
        {
            
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            FoodEvent.AddStrength.Invoke(_foodStrength);
            DestroyItSelf();
        }
    }
}