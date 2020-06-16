using System;
using UnityEngine;

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            var direction = (fingerDownPosition - fingerUpPosition).normalized;
            if ((direction.x <= 0.7f || direction.x >= -0.7f) && direction.y >= 0.7f)
            {
                SendSwipe(SwipeDirection.Up);
            }
            else if (direction.x >= 0.7f && (direction.y <= 0.7f || direction.y >= -0.7f))
            {
                SendSwipe(SwipeDirection.Right);
            }
            else if ((direction.x < 0.7f || direction.x >= -0.7f) && direction.y < -0.7f)
            {
                SendSwipe(SwipeDirection.Down);
            }
            else if (direction.x < -0.7f && (direction.y < 0.7f || direction.y > -0.7f))
            {
                SendSwipe(SwipeDirection.Left);
            }

            fingerDownPosition = fingerUpPosition;
        }
    }

    private bool SwipeDistanceCheckMet()
    {
        return MovementDistance() > minDistanceForSwipe;
    }

    private float MovementDistance()
    {
        return Vector3.Distance(fingerDownPosition, fingerUpPosition);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
}