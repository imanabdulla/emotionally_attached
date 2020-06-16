using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            AudioClip clickSound = AudioManager.audioManager.soundClip.click;
            AudioManager.audioManager.PlaySound(clickSound, false, 1f);
        });
    }
}
