using Events;
using UnityEngine;

namespace Core
{
    public abstract class ObjectBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            Initialization();
        }

        private void Start()
        {
            OnStart();
            LevelEvent.DestroyAllObjects.AddListener(DestroyItSelf);
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