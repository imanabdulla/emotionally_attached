using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookButton : MonoBehaviour
{
    [SerializeField] private GameObject pie, pizza, pieIngredints, pizzaIngredints;
    
    private void OnEnable()
    {
        // if(pie.ActiveSelf)
        // {
        //     GetComponent<Button>().onClick.AddListener (delegate {
        //         pieIngredints.SetActive (false);
        //     });
        // }
        // else if (pizza.ActiveSelf)
        // {
        //     GetComponent<Button>().onClick.AddListener (delegate {
        //         pizzaIngredints.SetActive (false);
        //     });

        // }
    }
    private void OnDisable ()
    {
        // if(pie.ActiveSelf)
        // {
        //     GetComponent<Button>().onClick.RemoveListener (delegate {
        //         pieIngredints.SetActive (false);
        //     });
        // }
        // else if (pizza.ActiveSelf)
        // {
        //     GetComponent<Button>().onClick.RemoveListener (delegate {
        //         pizzaIngredints.SetActive (false);
        //     });
        // }
    }
}
