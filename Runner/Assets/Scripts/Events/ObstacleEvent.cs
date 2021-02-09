using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class ObstacleEvent
    {
        public static PlayerMoveObstacle PlayerMoveObstacle = new PlayerMoveObstacle();
        public static PlayerWinsObstacle PlayerWinsObstacle = new PlayerWinsObstacle();
    }
    
    public class PlayerMoveObstacle : UnityEvent <GameObject>{}
    public class PlayerWinsObstacle : UnityEvent {}
}