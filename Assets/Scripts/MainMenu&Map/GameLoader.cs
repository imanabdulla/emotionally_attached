using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        StartCoroutine(LoadGame ());
    }
    IEnumerator LoadGame ()
    {
        AsyncOperation operation =SceneManager.LoadSceneAsync("MainMenu&Map", LoadSceneMode.Single);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
