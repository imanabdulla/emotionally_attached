using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField]private string[] speech;

    private void Start()
    {
        PopupSpeech.popupSpeech.OpenPopup(speech);
        StartCoroutine(OpenBook ());
    }

    private IEnumerator OpenBook()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().enabled = true;
    }
}
