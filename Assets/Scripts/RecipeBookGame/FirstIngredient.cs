using UnityEngine;

public class FirstIngredient : MonoBehaviour
{
    [SerializeField] private GameObject counter;
    [SerializeField] private Dragging[] allIngredients;

    private void Start()
    {
        GetComponent<Dragging>().OnItemDrop += AfterFirstItemDropped;
    }

    private void AfterFirstItemDropped()
    {
        gameObject.tag = "Droppables";
        counter.tag = "Untagged";
        GetComponent<Dragging>().OnItemDrop -= AfterFirstItemDropped;
    }

    private void Update()
    {
        for(int i = 0; i < allIngredients.Length-1; i++)
        {
            if (allIngredients[i].alreadyDropped)
            {
                allIngredients[i].tag = "Droppables";
                allIngredients[i + 1].enabled = true;
            }
        }
    }

}
