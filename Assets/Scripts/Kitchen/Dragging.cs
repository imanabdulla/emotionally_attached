using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragDropData
{
    public GameObject dragItem;
    public Vector2 dragItemNewSize;
    public GameObject dropArea;
    public Vector2 dropPoint;
}

public class Dragging : MonoBehaviour
{
    private DragDropData data = new DragDropData();
    private GameObject dropArea;
    private Vector3 offset, primaryPosition, dropPosition;
    private Vector2 dropPoint;
    private float zCoord;
    [SerializeField] private bool isDropped;
    [SerializeField] private bool isDroppedOnPoint;
    [HideInInspector] public bool alreadyDropped;
    public Vector2 dragItemNewSize;
    public static event Action<DragDropData> OnDrop = delegate { };
    public  event Action OnItemDrop = delegate { };

    private void OnMouseDown()
    {
        if (InputManager.inputManager.gameObject.activeSelf)
        {
            InputManager.inputManager.type = InputManager.InputType.DRAG;
            zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
            offset = transform.position - GetMouseInWorldPosition();
            primaryPosition = transform.position;
            alreadyDropped = false;
            if (FindObjectOfType<SwipeDetector>() != null)
                FindObjectOfType<SwipeDetector>().enabled = false;
        }
    }

    private void OnMouseDrag()
    {
        if (InputManager.inputManager.gameObject.activeSelf)
        {
            if (InputManager.inputManager.type == InputManager.InputType.DRAG)
                transform.position = GetMouseInWorldPosition() + offset;
        }
    }
    private void OnMouseUp()
    {
        if (InputManager.inputManager.gameObject.activeSelf)
        {
            if (InputManager.inputManager.type == InputManager.InputType.DRAG)
            {
                if (isDropped)
                {
                    if (isDroppedOnPoint) transform.position = dropPoint;
                    else transform.position = dropPosition;

                    data.dragItem = gameObject;
                    data.dropArea = this.dropArea;
                    data.dragItemNewSize = this.dragItemNewSize;
                    data.dropPoint = this.dropPoint;
                    OnDrop(data);
                    OnItemDrop();
                    alreadyDropped = true;
                    isDropped = false;
                }
                else
                {
                    transform.position = primaryPosition;
                }
                InputManager.inputManager.type = InputManager.InputType.NONE;

                if (FindObjectOfType<SwipeDetector>() != null)
                    FindObjectOfType<SwipeDetector>().enabled = true;
            }
        }
    }
    private Vector3 GetMouseInWorldPosition()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private Vector3 GetObjectInScreenPoint()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(GetObjectInScreenPoint());
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Droppables"))
            {
                this.dropPosition = hit.transform.position;
                this.dropArea = hit.collider.gameObject;
                this.dropPoint = hit.point;
                isDropped = true;
            }
            else
            {
                isDropped = false;
            }
        }
    }
}