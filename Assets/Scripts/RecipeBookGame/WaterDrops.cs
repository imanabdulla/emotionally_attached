using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrops : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag ("WaterDrop"))
        {
            other.transform.position = other.transform.parent.position;
        }   
    }
}
