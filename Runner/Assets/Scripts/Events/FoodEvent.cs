using UnityEngine.Events;

namespace Events
{
    public static class FoodEvent
    {
        public static readonly AddStrength AddStrength = new AddStrength();
    }
    public class AddStrength : UnityEvent <float> {}
}