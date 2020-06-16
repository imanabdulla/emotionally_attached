using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private string[]  billAndWalletSpeech;
    [SerializeField] private RectTransform  billAndWalletTransform;
    [SerializeField] private string[] toolBoxspeech;
    [SerializeField] private RectTransform toolBoxsTransfrom;

    void Start()
    {
        var value = PlayerPrefs.GetInt("MAP-INSTRUCTIONS", 0);
        if (value == 0)
        {
            StartCoroutine("PopUp");
            PlayerPrefs.SetInt("MAP-INSTRUCTIONS", 1);
        }
    }
    IEnumerator  PopUp()
    {
        PopupSpeech.popupSpeech.GetComponent<RectTransform>().position = toolBoxsTransfrom.position;
        PopupSpeech.popupSpeech.OpenPopup(toolBoxspeech);

        yield return new WaitForSeconds(5);

        PopupSpeech.popupSpeech.ClosePopup();

        yield return new WaitForSeconds(2);

        PopupSpeech.popupSpeech.GetComponent<RectTransform>().position = billAndWalletTransform.position;
        PopupSpeech.popupSpeech.OpenPopup(billAndWalletSpeech);

        yield return new WaitForSeconds(5);

        PopupSpeech.popupSpeech.ClosePopup();

    }
}
