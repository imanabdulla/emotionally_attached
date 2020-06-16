using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPlayButtonClick : MonoBehaviour
{

    [SerializeField] private GameObject map, mainMenu;

    public void OnButtonClick()
    {
        if (PlayerPrefs.GetInt("STORY") == 0)
        {
            ScenesManager.scenesManager.LoadScene("Story");
            PlayerPrefs.SetInt("STORY", 1);
        }
        else
        {
            map.SetActive(true);
            mainMenu.SetActive(false);
            FindObjectOfType<BillsAndWallets>().GetComponent<Canvas>().enabled = true;
        }
    }
}