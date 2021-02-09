using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class CameraEvent
    {
        public static SetPlayerAsTarget SetPlayerAsTarget = new SetPlayerAsTarget();
        public static ResetTarget ResetTarget = new ResetTarget();
    }
    public class SetPlayerAsTarget : UnityEvent <Transform> {}
    public class ResetTarget : UnityEvent {}
}