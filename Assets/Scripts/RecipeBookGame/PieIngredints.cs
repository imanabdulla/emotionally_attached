using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieIngredints : MonoBehaviour
{
    [SerializeField] private int counter ,numOfIngredints;
    [SerializeField] private GameObject cookButton;
    [SerializeField] private string[] speech;

    private void OnEnable() {
        Dragging.OnDrop += CountIngredints;
    }

    private void OnDisable() {
        Dragging.OnDrop -= CountIngredints;
    }

    public void AfterIngredinetsDisplay () {
        PopupSpeech.popupSpeech.OpenPopup(speech);
        Invoke("DisableAnimator", 1);
    }

    private void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void CountIngredints (DragDropData data) {
        counter++;
        if (counter == 1)
        {
            //after player drop first ingredint
            PopupSpeech.popupSpeech.ClosePopup();
        }
        else if(counter == numOfIngredints)
        {
            //after player drop all ingredints on the counter
            cookButton.SetActive(true);
        }
    }
}
