using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerIce : MonoBehaviour
{
    [SerializeField] private GameObject hairDrier, freezerFoodDroppableArea;
    [SerializeField] private Sprite[] iceStates;
     private int counter;

    private Coroutine coroutine;
    private bool isStartToMelt, isStopToMelt;


    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(hairDrier.transform.position, hairDrier.transform.forward, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Ice"))
            {
                if (!isStartToMelt)
                {
                    coroutine = StartCoroutine("MeltIce");
                    isStartToMelt = true;
                    isStopToMelt = false;

                    var clip = AudioManager.audioManager.soundClip.hairDrier;
                    AudioManager.audioManager.PlaySound(clip, true, 1f);
                }
            }
            else
            {
                AudioManager.audioManager.StopSound();

                if (isStartToMelt)
                {
                    if (!isStopToMelt)
                    {
                        if (coroutine != null) StopCoroutine(coroutine);
                        isStopToMelt = true;
                        isStartToMelt = false;
                    }
                }
            }
        }
        else
        {
            AudioManager.audioManager.StopSound();
            if (isStartToMelt)
            {
                if (!isStopToMelt)
                {
                    if (coroutine != null) StopCoroutine(coroutine);
                    isStopToMelt = true;
                    isStartToMelt = false;
                }
            }
        }
    }

    private IEnumerator MeltIce()
    {
        while (counter < iceStates.Length)
        {
            GetComponent<SpriteRenderer>().sprite = iceStates[counter];
            yield return new WaitForSeconds(1f);
            counter++;
        }
        GetComponent<SpriteRenderer>().sprite = null;
        freezerFoodDroppableArea.SetActive(true);
        foreach (var food in AllFoodArea.allFoodArea.allFood)
        {
            if (!food.isVanished)
            {
                food.GetComponent<BoxCollider2D>().enabled = true;
                food.transform.position = new Vector3(food.transform.position.x, food.transform.position.y, food.transform.position.z - 1);
            }
        }
        enabled = false;
    }
}