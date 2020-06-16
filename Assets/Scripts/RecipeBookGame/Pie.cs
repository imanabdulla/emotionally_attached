using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pie : MonoBehaviour
{

    [SerializeField] private GameObject pizza, pizzaPlants, pieIngridents; 

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
                pizza.SetActive(false);
                pizzaPlants.SetActive(false);
                pieIngridents.SetActive(true);
                GetComponent<Collider2D> ().enabled = false ;
            }
        }
    }    
}