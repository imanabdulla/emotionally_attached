using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public bool TranstionFromRightToLeft, TranstionFromLeftToRight;
    public float speed, step;

    private Vector3 nextPosition;
    void Awake()
    {
        SwipeDetector.OnSwipe += TranstionRoom;
    }

    void TranstionRoom(SwipeData data)
    {
        switch (data.Direction)
        {
            case SwipeDirection.Right:
                nextPosition = transform.position + (transform.right * step);
                TranstionFromRightToLeft = false;
                TranstionFromLeftToRight = true;
                break;
            case SwipeDirection.Left:
                nextPosition = transform.position - (transform.right * step);
                TranstionFromLeftToRight = false;
                TranstionFromRightToLeft = true;
                break;
        }
    }

    void Update()
    {
        if (TranstionFromLeftToRight)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * speed);
        }
        else if (TranstionFromRightToLeft)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * speed);
        }
    }
}
