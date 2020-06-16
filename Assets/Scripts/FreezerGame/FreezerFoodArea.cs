using UnityEngine;
using TMPro;

public class FreezerFoodArea : MonoBehaviour
{
    private void OnEnable()
    {
        Dragging.OnDrop += AfterPuttingInFreezer;
    }
    private void OnDisable()
    {
        Dragging.OnDrop -= AfterPuttingInFreezer;
    }

    private void Update()
    {
        if (AllFoodArea.allFoodArea.counter == 4 && AllFoodArea.allFoodArea.allFood.Count == 4)
        {
            //all food is vanished
            AllFoodArea.allFoodArea.gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
                "<size=100> Agh! </size>" + "\n" + "The frozen food went bad" + "\n" + "Mom will have to make a run to the grocery store" + "\n" + "She paid $20";
            AllFoodArea.allFoodArea.gameEnd.transform.GetChild(2).gameObject.SetActive(false);
            AllFoodArea.allFoodArea.gameEnd.SetActive(true);

            //new wallets
            BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) - 20).ToString();

            //new grocery bill
            BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) + 20).ToString();

            //new bills
            BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                (int.Parse(BillsAndWallets.billsAndWallets.bills.text) + 20).ToString();
            enabled = false;
        }
        else if (AllFoodArea.allFoodArea.counter == AllFoodArea.allFoodArea.allFood.Count)
        {
            if (AllFoodArea.allFoodArea.savedMoney >= 20)
            {
                //end game
                AllFoodArea.allFoodArea.gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
                            "<size=100> Great! </size>" + "\n" + "<size=70> You saved </size> <size=120>$20</size>";

                var clip = AudioManager.audioManager.soundClip.greatYay;
                AudioManager.audioManager.PlaySound(clip, false, 1f);
            }
            else
            {
                //end game
                AllFoodArea.allFoodArea.gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
                            "<size=100> Good! </size>" + "\n" + "<size=70> You saved </size>" + "<size=120> $" + AllFoodArea.allFoodArea.savedMoney.ToString() + "</size>";

                var clip = AudioManager.audioManager.soundClip.yay;
                AudioManager.audioManager.PlaySound(clip, false, 1f);
            }
            AllFoodArea.allFoodArea.gameEnd.SetActive(true);

            //new wallets
            BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) + AllFoodArea.allFoodArea.savedMoney).ToString();

            //new grocery bill
            BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) - AllFoodArea.allFoodArea.savedMoney).ToString();

            //new bills
            BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                (int.Parse(BillsAndWallets.billsAndWallets.bills.text) - AllFoodArea.allFoodArea.savedMoney).ToString();
            enabled = false;
        }
    }

private void AfterPuttingInFreezer(DragDropData data)
    {
        if (data.dragItem.GetComponent<FreezerFood>() != null)
        {
            if (this.gameObject == data.dropArea)
            {
                AllFoodArea.allFoodArea.savedMoney += data.dragItem.GetComponent<FreezerFood>().groceryBillValue;
                data.dragItem.GetComponent<FreezerFood>().enabled = false;
                data.dragItem.GetComponent<Animator>().enabled = false;
                data.dragItem.GetComponent<FreezerFood>().timer.gameObject.SetActive(false);

                AllFoodArea.allFoodArea.allFood.Remove(data.dragItem.GetComponent<FreezerFood>());
                //decrease grocery bill
                BillsAndWallets.billsAndWallets.groceryBills.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) - data.dragItem.GetComponent<FreezerFood>().groceryBillValue).ToString();
                BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.bills.text) - int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text)).ToString();

                //increase wallet
                BillsAndWallets.billsAndWallets.wallets.text = BillsAndWallets.billsAndWallets.savedMoney.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) + data.dragItem.GetComponent<FreezerFood>().groceryBillValue).ToString();


                if (AllFoodArea.allFoodArea.allFood.Count == 0)
                {
                    //end game
                    AllFoodArea.allFoodArea.gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
                                    "<size=100> Great! </size>" + "\n" + "<size=70> You saved </size> <size=120>$20</size>";
                    AllFoodArea.allFoodArea.gameEnd.SetActive(true);

                    var clip = AudioManager.audioManager.soundClip.greatYay;
                    AudioManager.audioManager.PlaySound(clip, false,1f);

                    //new wallets
                    BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                        (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) + 20).ToString();

                    //new grocery bill
                    BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) - 20).ToString();

                    //new bills
                    BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                        (int.Parse(BillsAndWallets.billsAndWallets.bills.text) - 20).ToString();

                }
            }
        }
    }
}
