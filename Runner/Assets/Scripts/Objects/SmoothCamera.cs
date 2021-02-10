using Events;
using UnityEngine;

namespace Objects
{
    public class SmoothCamera : MonoBehaviour
    {
        [SerializeField] private float smoothSpeed = 3;
        [SerializeField] private Vector3 offset;

        private Transform _targetTransform;
        private bool _isTargetSetted;


        private void Awake()
        {
            CameraEvent.SetPlayerAsTarget.AddListener(SetTarget);
            CameraEvent.ResetTarget.AddListener(ResetTarget);
        }

        private void SetTarget(Transform target)
        {
            _targetTransform = target;
            _isTargetSetted = true;
        }

        private void ResetTarget()
        {
            _targetTransform = null;
            _isTargetSetted = false;
        }

        private void LateUpdate()
        {
            if (_isTargetSetted == false) return;
            var desiredPosition = _targetTransform.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}