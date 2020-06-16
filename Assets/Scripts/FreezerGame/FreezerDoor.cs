using UnityEngine;

public class FreezerDoor : MonoBehaviour
{
    private bool isOpen, isPopupClosed;
    [SerializeField] private string[] speech;

    private void Update()
    {
        if (isOpen)
        {
            if (!isPopupClosed)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        PopupSpeech.popupSpeech.ClosePopup();
                        isPopupClosed = true;
                    }
                }
#if UNITY_EDITOR
                if (Input.GetMouseButtonDown(0))
                {
                    PopupSpeech.popupSpeech.ClosePopup();
                    isPopupClosed = true;
                }
#endif
            }
        }
    }

    private void OnMouseDown()
    {
        if (InputManager.inputManager.gameObject.activeSelf)
        {
            InputManager.inputManager.type = InputManager.InputType.TAP;
        }
    }
    private void OnMouseUp()
    {
        if (InputManager.inputManager.gameObject.activeSelf)
        {
            if (InputManager.inputManager.type == InputManager.InputType.TAP)
            {
                if (isOpen)
                {
                    //if (!isPopupClosed)
                    //{
                    //    PopupSpeech.popupSpeech.ClosePopup();
                    //    isPopupClosed = true;
                    //}

                    GetComponent<Animator>().SetTrigger("Close");
                    isOpen = false;
                }
                else
                {
                    PopupSpeech.popupSpeech.OpenPopup(speech);
                    GetComponent<Animator>().SetTrigger("Open");
                    isOpen = true;
                    isPopupClosed = false;
                }
                InputManager.inputManager.type = InputManager.InputType.NONE;
            }
        }
    }
}
