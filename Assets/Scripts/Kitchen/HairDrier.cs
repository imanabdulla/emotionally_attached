using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDrier : MonoBehaviour
{
    private bool moveToToolBox;
    private GameObject hairDrier;
    [SerializeField] private float speed;

    private void Awake()
    {
        hairDrier = GameObject.Find("ToolBox").transform.GetChild(0).GetChild(0).gameObject;

        if (!GameManager.gameManager.isHairDrierInToolBox)
        {
            hairDrier.SetActive(false);
            GetComponent<Animator>().enabled = false;
        }
        else
        {
            hairDrier.SetActive(true);
            enabled = false;
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
                GetComponent<Animator>().enabled = true;
            }
        }
    }

    public void Move()
    {
        moveToToolBox = true;
        if (FindObjectOfType<SwipeDetector>() != null)
            FindObjectOfType<SwipeDetector>().enabled = false;

    }

    private void Update()
    {
        if (moveToToolBox)
        {
            
            transform.position = Vector3.Lerp(transform.position, hairDrier.transform.position, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, hairDrier.transform.position) < 0.3f)
            {
                if (FindObjectOfType<SwipeDetector>() != null)
                    FindObjectOfType<SwipeDetector>().enabled = true;

                GameManager.gameManager.isHairDrierInToolBox = true;
                hairDrier.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
