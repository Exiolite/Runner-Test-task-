using System;
using UnityEngine;

namespace Core
{
    public abstract class ObjectBehaviour : MonoBehaviour
    {
        protected Core Core;
        
        private void Awake()
        {
            Core = Core.Instance;
            Initialization();
        }

        private void Start()
        {
            OnStart();
        }

        private void Update()
        {
            Execute();
        }

        protected abstract void Initialization();
        protected abstract void OnStart();
        protected abstract void Execute();
        protected abstract void BeforeDestroy();

        protected void DestroyItSelf()
        {
            BeforeDestroy();
            Destroy(gameObject);
        }
    }
}