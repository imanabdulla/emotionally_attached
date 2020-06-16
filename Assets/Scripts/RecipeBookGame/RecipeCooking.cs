using System.Collections;
using UnityEngine;
using TMPro;

public class RecipeCooking : MonoBehaviour
{

    [SerializeField] private GameObject pizza, pizzaPlants, pizzaFruits, cookedPizza, pie, piePlants, pieFruits, cookedPie, waterDrops, gameEnd;

    private void OnEnable()
    {
        StartCoroutine("DuringCooking");
    }

    IEnumerator DuringCooking()
    {
        if (pizza.activeSelf)
        {
            yield return new WaitForSeconds(3);
            pizzaFruits.SetActive(true);
            yield return new WaitForSeconds(3);
            waterDrops.SetActive(true);
            pizzaFruits.SetActive(false);
            yield return new WaitForSeconds(2);
            pizzaPlants.SetActive(true);
            yield return new WaitForSeconds(1);
            waterDrops.SetActive(false);
            foreach (var anim in pizzaPlants.GetComponentsInChildren<Animator>())
            {
                anim.enabled = true;
            }
            yield return new WaitForSeconds(1);
            cookedPizza.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(3);

            gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
            "<size=100> Yay! </size>" + "\n" +
            "<size=70> You planted a Pizza</size>" + "\n" +
            "<size=70> You saved </size> <size=100>$20</size>";

            gameEnd.SetActive(true);

            var clip = AudioManager.audioManager.soundClip.greatYay;
            AudioManager.audioManager.PlaySound(clip, false, 1f);


            //new wallets
            BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) + 20).ToString();

            //new grocery bill
            BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) - 20).ToString();

            //new bills
            BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                (int.Parse(BillsAndWallets.billsAndWallets.bills.text) - 20).ToString();

            gameObject.SetActive(false);


        }
        else if (pie.activeSelf)
        {
            yield return new WaitForSeconds(3);
            pieFruits.SetActive(true);
            yield return new WaitForSeconds(3);
            waterDrops.SetActive(true);
            pieFruits.SetActive(false);
            yield return new WaitForSeconds(2);
            piePlants.SetActive(true);
            yield return new WaitForSeconds(1);
            waterDrops.SetActive(false);
            foreach (var anim in piePlants.GetComponentsInChildren<Animator>())
            {
                anim.enabled = true;
            }
            yield return new WaitForSeconds(1);
            cookedPie.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(3);
            gameEnd.transform.GetChild(1).GetComponent<TMP_Text>().text =
            "<size=100> Yay! </size>" + "\n" +
            "<size=70> You planted an Apple Pie</size>" + "\n" +
            "<size=70> You saved </size> <size=100>$20</size>";

            gameEnd.SetActive(true);

            var clip = AudioManager.audioManager.soundClip.greatYay;
            AudioManager.audioManager.PlaySound(clip, false, 1f);


            //new wallets
            BillsAndWallets.billsAndWallets.savedMoney.text = BillsAndWallets.billsAndWallets.wallets.text =
                (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) + 20).ToString();
            //PlayerPrefs.SetInt("SAVEDMONEYBILLS", int.Parse(BillsAndWallets.billsAndWallets.savedMoney.text));

            //new grocery bill
            BillsAndWallets.billsAndWallets.groceryBills.text = (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) - 20).ToString();
            //PlayerPrefs.SetInt("GROCERYBILLS", int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text));

            //new bills
            BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                (int.Parse(BillsAndWallets.billsAndWallets.bills.text) - 20).ToString();

            gameObject.SetActive(false);
        }
    }

}
