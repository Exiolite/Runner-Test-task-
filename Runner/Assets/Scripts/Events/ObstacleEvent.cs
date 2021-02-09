using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class ObstacleEvent
    {
        public static readonly PlayerMoveObstacle PlayerMoveObstacle = new PlayerMoveObstacle();
        public static readonly PlayerWinsObstacle PlayerWinsObstacle = new PlayerWinsObstacle();
    }
    
    public class PlayerMoveObstacle : UnityEvent <GameObject>{}
    public class PlayerWinsObstacle : UnityEvent {}
}