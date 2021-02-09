using UnityEngine.Events;

namespace Events
{
    public static class GuiEvent
    {
        public static readonly UpdateStrengthCounter UpdateStrengthCounter = new UpdateStrengthCounter();
    }
    public class UpdateStrengthCounter : UnityEvent <float> {}
}