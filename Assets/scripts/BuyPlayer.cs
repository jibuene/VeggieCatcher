using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPlayer : MonoBehaviour
{
    [SerializeField] private Text ItemText;
    [SerializeField] private int playerId;
    [SerializeField] private int itemCost;
    private int playerSelected;
    private float hs;

    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(buyItem);
        CheckIfPlayerActive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerActive();
    }
    void buyItem()
    {
        hs = PlayerPrefs.GetFloat("HighScore");
        playerSelected = PlayerPrefs.GetInt("Player");
        if (hs >= itemCost && playerSelected != playerId)
        {
            PlayerPrefs.SetInt("Player", playerId);
            ItemText.text = "ON";
            return;
        }
    }
    void CheckIfPlayerActive ()
    {
        hs = PlayerPrefs.GetFloat("HighScore");
        if (hs == 0)
        {
            PlayerPrefs.SetInt("Player", 1);
        }
        playerSelected = PlayerPrefs.GetInt("Player");
        if (playerSelected == playerId)
        {
            ItemText.text = "ON";
        } else if (hs >= itemCost && playerSelected != playerId)
        {
            ItemText.text = "OFF";
        } else
        {
            ItemText.text = itemCost.ToString();
        }
    }
}
