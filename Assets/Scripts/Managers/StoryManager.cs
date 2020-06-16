using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    #region singleton
    public static StoryManager storyManager;
    private void Awake()
    {
        if (storyManager != null)
        {
            Destroy(GameObject.Find("StoryManager"));
        }
        storyManager = this;
        DontDestroyOnLoad(storyManager.gameObject);
    }
    #endregion


    private void Start()
    {
        AudioClip[] clips = new AudioClip[1];
        float[] volumes = new float[1];
        clips[0] = AudioManager.audioManager.musicClip.rainsSound;
        volumes[0] = 1f;
        AudioManager.audioManager.PlayMusic(clips, volumes, true);
    }

    public void LoadSceneInCoroutine(string _name)
    {
        StartCoroutine(Load(_name));
    }

    IEnumerator Load(string _name)
    {
        var op = SceneManager.LoadSceneAsync(_name);

        while (!op.isDone)
        {
            yield return null;
        }

        var mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        mainMenu.SetActive(false);
        mainMenu.transform.parent.GetChild(2).gameObject.SetActive(true);//pop-up
        mainMenu.transform.parent.GetChild(0).gameObject.SetActive(true);//map
        FindObjectOfType<BillsAndWallets>().GetComponent<Canvas>().enabled = true;//bills&wallets canvas
    }

}
