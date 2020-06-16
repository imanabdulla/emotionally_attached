using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager gameManager;
    public bool isHairDrierInToolBox;

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(GameObject.Find("GameManager"));
        }
        gameManager = this;
        DontDestroyOnLoad(gameManager.gameObject);
    }
    #endregion

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
        mainMenu.transform.parent.GetChild(0).gameObject.SetActive(true);
    }

}
