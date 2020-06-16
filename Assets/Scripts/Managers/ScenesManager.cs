using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    #region singleton
    public static ScenesManager scenesManager;

    private void Awake()
    {
        if (scenesManager != null)
        {
            Destroy(GameObject.Find("ScenesManager"));
        }
        scenesManager = this;
        DontDestroyOnLoad(scenesManager.gameObject);
    }
    #endregion
    public void LoadScene(string _name)
    {
        SceneManager.LoadSceneAsync(_name);
    }
}