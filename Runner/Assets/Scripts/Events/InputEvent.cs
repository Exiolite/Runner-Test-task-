using UnityEngine.Events;

namespace Events
{
    public static class InputEvent
    {
        public static readonly HorizontalSwipe HorizontalSwipe = new HorizontalSwipe();
    }
    public class HorizontalSwipe : UnityEvent <bool> {}
}