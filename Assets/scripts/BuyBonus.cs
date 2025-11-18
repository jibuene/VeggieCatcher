using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBonus : MonoBehaviour
{
    [SerializeField] private Text ItemText;
    [SerializeField] private string ItemName;
    [SerializeField] private int itemCost;
    private int itemEnabled;
    private float coins;

    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(buyItem);
        itemEnabled = PlayerPrefs.GetInt(ItemName);
        if (itemEnabled == 1)
        {
            ItemText.text = ItemName + ": ON";
        } else if (itemEnabled == 2)
        {
            ItemText.text = ItemName + ": OFF";
        } else
        {
            ItemText.text = ItemName + ": " + itemCost;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void buyItem()
    {
        itemEnabled = PlayerPrefs.GetInt(ItemName);
        if (itemEnabled == 1)
        {
            PlayerPrefs.SetInt(ItemName, 2);
            ItemText.text = ItemName + ": OFF";
            return;
        } else if (itemEnabled == 2)
        {
            PlayerPrefs.SetInt(ItemName, 1);
            ItemText.text = ItemName + ": ON";
            return;
        }
        coins = PlayerPrefs.GetFloat("Coins");
        if (coins > itemCost)
        {
            PlayerPrefs.SetFloat("Coins", (PlayerPrefs.GetFloat("Coins") - itemCost));
            PlayerPrefs.SetInt(ItemName, 1);
            ItemText.text = ItemName + ": ON";
        }
    }
}
