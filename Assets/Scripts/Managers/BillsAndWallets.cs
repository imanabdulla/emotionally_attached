using UnityEngine;
using UnityEngine.UI;

public class BillsAndWallets : MonoBehaviour
{
    public Text bills, wallets, waterBills, electricityBills, groceryBills, cashBills, otherBills, savedMoney, totalBills;

    #region singleton
    public GameObject eventSystem;
    public static BillsAndWallets billsAndWallets;

    private void Awake()
    {
        if (billsAndWallets != null)
        {
            Destroy(GameObject.Find("Bills&WalletsCanvas"));
            Destroy(GameObject.Find("EventSystem"));
        }

        billsAndWallets = this;
        DontDestroyOnLoad(billsAndWallets);
        DontDestroyOnLoad(eventSystem);
    }
    #endregion

    private void Start()
    {
        SetBillsAndWallets();
    }

    private void SetBillsAndWallets()
    {
        waterBills.text = 141.ToString();//PlayerPrefs.GetInt("WATERBILLS", 141).ToString();
        electricityBills.text = 268.ToString();//PlayerPrefs.GetInt("ELECTRICITYBILLS", 268).ToString();
        groceryBills.text = 186.ToString();//PlayerPrefs.GetInt("GROCERYBILLS", 186).ToString();
        cashBills.text = 549.ToString();//PlayerPrefs.GetInt("CASHBILLS", 549).ToString();
        otherBills.text = 470.ToString();//PlayerPrefs.GetInt("OTHERBILLS", 470).ToString();
        savedMoney.text = wallets.text = 117.ToString();// = PlayerPrefs.GetInt("SAVEDMONEYBILLS", 117).ToString();
        totalBills.text = bills.text = 1731.ToString();//(int.Parse(waterBills.text) + int.Parse(electricityBills.text) + int.Parse(groceryBills.text) + int.Parse(cashBills.text) + int.Parse(otherBills.text)).ToString();
    }

}