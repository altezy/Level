using TMPro;
using UnityEngine;
 
public class InventoryView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemsList;

    public void AddItem(string item)
    {
        itemsList.text += item + "\n";
    }

    public void RemoveItem(string item)
    {
        itemsList.text = itemsList.text.Replace(item + "\n", "");
    }
}