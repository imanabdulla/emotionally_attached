using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum InputType { NONE, TAP, DRAG, SWIPE }
    public InputType type;

    #region singleton
    public static InputManager inputManager;
    private void Awake()
    {
        if (inputManager == null)
        {
            inputManager = this;
            DontDestroyOnLoad(inputManager.gameObject);
        }
        else
        {
            Destroy(GameObject.Find("InputManager"));
            inputManager = this;
            DontDestroyOnLoad(inputManager);
        }
    }
    #endregion
}