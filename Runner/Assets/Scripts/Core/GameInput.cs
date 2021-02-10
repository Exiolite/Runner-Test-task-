using Events;
using UnityEngine;

namespace Core
{
    public class GameInput : MonoBehaviour
    {
        // Код свайпа не мой, использовал его когда-то для другого проекта.


        //SwipteInput
        private const float MaxSwipeTime = 0.5f;
        private const float MinSwipeDistance = 0.17f;

        private static bool _swipedRight = false;
        private static bool _swipedLeft = false;
        private static bool _swipedUp = false;
        private static bool _swipedDown = false;

        private bool debugWithArrowKeys = true;

        Vector2 _startPos;
        float _startTime;


        private void Update()
        {
            SwipeInput();
        }


        private void SwipeInput()
        {
            _swipedRight = false;
            _swipedLeft = false;
            _swipedUp = false;
            _swipedDown = false;

            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    _startPos = new Vector2(t.position.x / (float) Screen.width, t.position.y / (float) Screen.width);
                    _startTime = Time.time;
                }

                if (t.phase == TouchPhase.Ended)
                {
                    if (Time.time - _startTime > MaxSwipeTime) // press too long
                        return;

                    Vector2 endPos = new Vector2(t.position.x / (float) Screen.width,
                        t.position.y / (float) Screen.width);

                    Vector2 swipe = new Vector2(endPos.x - _startPos.x, endPos.y - _startPos.y);

                    if (swipe.magnitude < MinSwipeDistance) // Too short swipe
                        return;

                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    {
                        // Horizontal swipe
                        if (swipe.x > 0)
                        {
                            _swipedRight = true;
                        }
                        else
                        {
                            _swipedLeft = true;
                        }
                    }
                    else
                    {
                        // Vertical swipe
                        if (swipe.y > 0)
                        {
                            _swipedUp = true;
                        }
                        else
                        {
                            _swipedDown = true;
                        }
                    }
                }
            }


            if (debugWithArrowKeys)
            {
                _swipedDown = _swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
                _swipedUp = _swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
                _swipedRight = _swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
                _swipedLeft = _swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
            }

            if (_swipedRight)
            {
                InputEvent.HorizontalSwipe.Invoke(true);
            }

            if (_swipedLeft)
            {
                InputEvent.HorizontalSwipe.Invoke(false);
            }
        }
    }
}