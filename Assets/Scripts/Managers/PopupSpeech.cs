using System.Collections;
using UnityEngine;
using TMPro;

public class PopupSpeech : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text text;
    private string[] speech;

    public static PopupSpeech popupSpeech;

    private void Awake()
    {
        popupSpeech = this;
    }

    public void OpenPopup(string[] _speech)
    {
        text.text = "";
        animator.SetTrigger("open");
        this.speech = _speech;
    }


    public void ClosePopup()
    {
        animator.SetTrigger("close");
    }


    public IEnumerator WriteSpeech()
    {
        for (int i = 0; i < speech.Length; i++)
        {
            text.text = speech[i];
            yield return new WaitForSeconds(4);
        }
    }
}
