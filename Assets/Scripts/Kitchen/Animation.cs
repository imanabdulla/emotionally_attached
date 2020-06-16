using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public bool isOpen;

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
                    GetComponent<Animator>().SetTrigger("Close");

                    isOpen = false;
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("Open");
                    isOpen = true;
                }
                InputManager.inputManager.type = InputManager.InputType.NONE;
            }
        }
    }
}