using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllFood : MonoBehaviour
{
    public List<FreezerFood> allFood;
    [SerializeField] private Collider2D iceCol;
    [SerializeField] private string[] gameStartSpeech;
    [SerializeField] private GameObject gameEnd;

    private bool stopChecking, closePopup, areDropped;

    private void Start()
    {
        PopupSpeech.popupSpeech.OpenPopup(gameStartSpeech);
    }

    private void Update()
    {
        if (!closePopup)
        {
            if (allFood[0].isDropped || allFood[1].isDropped || allFood[2].isDropped || allFood[3].isDropped)
            {
                PopupSpeech.popupSpeech.ClosePopup();
                closePopup = true;
            }
        }

        else if (!stopChecking)
        {
            if (allFood[0].isDropped && allFood[1].isDropped && allFood[2].isDropped && allFood[3].isDropped)
            {
                AfterDroppingAllFood();
                areDropped = true;
                stopChecking = true;
            }
        }

        else if (areDropped)
        {
            if (allFood[0].isVanished && allFood[1].isVanished && allFood[2].isVanished && allFood[3].isVanished)
            {
                //all food is vanished
                gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
                    "Agh!" + "\n" + "The frozen food went bad"+"\n"+"Mom will have to make a run to the grocery store"+"\n"+"She paid $20";
                gameEnd.transform.GetChild(2).gameObject.SetActive(false);
                gameEnd.SetActive(true);

                //new wallets
                BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) - 20).ToString();

                //new grocery bill
                BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) + 20).ToString();

                //new bills
                BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.bills.text) + 20).ToString();
                areDropped = false;
            }
        }
    }

    private void AfterDroppingAllFood()
    {
        //enable ice collider
        iceCol.enabled = true;
    }
}