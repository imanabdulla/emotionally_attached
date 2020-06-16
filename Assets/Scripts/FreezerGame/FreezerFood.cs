using UnityEngine;
using UnityEngine.UI;

public class FreezerFood : MonoBehaviour
{
    public int groceryBillValue;
    public bool isVanished, isDropped, isTimerOn;
    public Slider timer;

    [SerializeField] private Animator animator;
    [SerializeField] private float timerSpeed = 0.1f;

    private Vector3 foodPos;

    private void OnEnable()
    {
        Dragging.OnDrop += AfterPuttingOnCabinet;
    }
    private void OnDisable()
    {
        Dragging.OnDrop -= AfterPuttingOnCabinet;
    }
    private void Update()
    {
        if (isTimerOn)
        {
            timer.value += Time.deltaTime * timerSpeed;
            if (timer.value > 1 - Time.deltaTime * timerSpeed)
            {
                timer.value = 1;
                timer.gameObject.SetActive(false);

                //animator
                animator.SetTrigger("Vanish");
                transform.position = foodPos;
                transform.localScale = Vector3.one;
                //increase grocery bill
                BillsAndWallets.billsAndWallets.groceryBills.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text) + groceryBillValue).ToString();
                BillsAndWallets.billsAndWallets.bills.text = BillsAndWallets.billsAndWallets.totalBills.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.bills.text) + int.Parse(BillsAndWallets.billsAndWallets.groceryBills.text)).ToString();

                //decrease wallet
                BillsAndWallets.billsAndWallets.wallets.text = BillsAndWallets.billsAndWallets.savedMoney.text =
                    (int.Parse(BillsAndWallets.billsAndWallets.wallets.text) - groceryBillValue).ToString();

                isVanished = true;
                if(AllFoodArea.allFoodArea !=null) AllFoodArea.allFoodArea.counter++;
                isTimerOn = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void AfterPuttingOnCabinet(DragDropData data)
    {
        if (this.gameObject == data.dragItem)
        {
            foodPos = transform.position;
            //open timer
            timer.gameObject.SetActive(true);
            //turn it on
            isTimerOn = true;
            isDropped = true;
            //disable dragging
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}