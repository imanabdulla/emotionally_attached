using System.Collections;
using UnityEngine;

public class RecipeBookInteraction : MonoBehaviour
{
    private GameObject navigationButtons, mainCam;
    [SerializeField] private float newSize, speed;
    [SerializeField] private string[] speech;

    private bool isTapped;

    private void Awake()
    {
        mainCam = Camera.main.gameObject;
        //navigationButtons = mainCam.GetComponent<CameraZoom>().NavigationButtons;
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
                if (!isTapped)
                {
                    StartCoroutine(StartRecipeBookGame());
                    isTapped = true;
                }
            }
        }
    }

    private IEnumerator StartRecipeBookGame()
    {
        PopupSpeech.popupSpeech.OpenPopup(speech);

        yield return new WaitForSeconds(2f);

        PopupSpeech.popupSpeech.ClosePopup();

        while (Camera.main.orthographicSize > newSize + 0.1f)
        {
            mainCam.transform.position = Vector3.Lerp(new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, -10), transform.position, Time.deltaTime * speed);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, Time.deltaTime * speed);

            yield return null;
        }

        ScenesManager.scenesManager.LoadScene("RecipeBookGame");
    }
}