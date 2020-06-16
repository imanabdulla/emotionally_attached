/*
 * That's it! Let's melt the frost with the hair dryer. Be quick! You mustn't let the food go bad. 
 */
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float newSize;
    [SerializeField] private float zoomSpeed, moveSpeed;
    [SerializeField] private string[] speech;

    private Vector3 nxtRightPos, nxtLeftPos;
    private bool startRightNav, startLeftNav;

    private void Awake()
    {
        Dragging.OnDrop += ZoomIn;
        SwipeDetector.OnSwipe += Move;
    }

    private void OnDisable()
    {
        Dragging.OnDrop -= ZoomIn;
        SwipeDetector.OnSwipe -= Move;

    }

    private void Update()
    {
        if (startRightNav)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, nxtRightPos, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(Camera.main.transform.position, nxtRightPos) < Time.deltaTime * moveSpeed)
            {
                StopRight();
            }
        }

        else if (startLeftNav)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, nxtLeftPos, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(Camera.main.transform.position, nxtLeftPos) < Time.deltaTime * moveSpeed)
            {
                StopLeft();
            }
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.RightArrow))
            NavigateLeft();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            NavigateRight();
#endif
    }

    public void NavigateRight()
    {
        InputManager.inputManager.type = InputManager.InputType.DRAG;
        nxtRightPos = new Vector3(Camera.main.transform.position.x + 2, Camera.main.transform.position.y, Camera.main.transform.position.z);
        startRightNav = true;
    }

    public void StopRight()
    {
        InputManager.inputManager.type = InputManager.InputType.NONE;
        nxtRightPos = nxtLeftPos = Camera.main.transform.position;
        startRightNav = false;
    }

    public void NavigateLeft()
    {
        InputManager.inputManager.type = InputManager.InputType.DRAG;
        nxtLeftPos = new Vector3(Camera.main.transform.position.x - 2, Camera.main.transform.position.y, Camera.main.transform.position.z);
        startLeftNav = true;
    }

    public void StopLeft()
    {
        InputManager.inputManager.type = InputManager.InputType.NONE;
        nxtRightPos = nxtLeftPos = Camera.main.transform.position;
        startLeftNav = false;
    }

    private void Move(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Left)
            NavigateRight();
        else if (data.Direction == SwipeDirection.Right)
            NavigateLeft();
    }

    private void ZoomIn(DragDropData data)
    {
        StartCoroutine(ChangeSize(data));
    }

    private IEnumerator ChangeSize(DragDropData data)
    {
        PopupSpeech.popupSpeech.OpenPopup(speech);

        yield return new WaitForSeconds(2f);

        PopupSpeech.popupSpeech.ClosePopup();

        while (Camera.main.orthographicSize > newSize + 0.1f)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), data.dropArea.transform.position, Time.deltaTime * zoomSpeed);
            //change camera size
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, Time.deltaTime * zoomSpeed);
            //change drag item size
            data.dragItem.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(data.dragItem.GetComponent<RectTransform>().sizeDelta, data.dragItemNewSize, Time.deltaTime * zoomSpeed * 0.5f);
            yield return null;
        }
        //start first mini game
        ScenesManager.scenesManager.LoadScene("FreezerGame");
    }
}