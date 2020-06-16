using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private GameObject pie, piePlants, pizzaIngridents;

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
                PopupSpeech.popupSpeech.ClosePopup();
                pie.SetActive(false);
                piePlants.SetActive(false);
                pizzaIngridents.SetActive(true);
            }
        }
    }
}
