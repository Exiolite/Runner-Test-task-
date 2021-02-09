using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class CameraEvent
    {
        public static readonly SetPlayerAsTarget SetPlayerAsTarget = new SetPlayerAsTarget();
        public static readonly ResetTarget ResetTarget = new ResetTarget();
    }
    public class SetPlayerAsTarget : UnityEvent <Transform> {}
    public class ResetTarget : UnityEvent {}
}