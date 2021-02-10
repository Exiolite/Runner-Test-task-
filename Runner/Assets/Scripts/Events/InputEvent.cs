using UnityEngine.Events;

namespace Events
{
    public static class InputEvent
    {
        public static HorizontalSwipe HorizontalSwipe = new HorizontalSwipe();
    }
    public class HorizontalSwipe : UnityEvent <bool> {}
}