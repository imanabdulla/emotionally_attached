using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFoodArea : MonoBehaviour
{
    public int counter, savedMoney;
    public List<FreezerFood> allFood;
    public GameObject gameEnd;

    public static AllFoodArea allFoodArea;

    void Awake()
    {
        allFoodArea = this;
        counter = savedMoney = 0;
    }
}
