using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDoorAnimation : MonoBehaviour
{
    public void GoOutOfTheKitchen ()
    {
        GameManager.gameManager.LoadSceneInCoroutine("MainMenu&Map");
    }

}
