using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEnemy : MonoBehaviour
{
    [SerializeField] private Text ItemText;
    [SerializeField] private int enemyId;
    [SerializeField] private int itemCost;
    private int enemySelected;
    private float hs;

    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(buyItem);
        CheckIfEnemyActive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfEnemyActive();
    }
    void buyItem()
    {
        hs = PlayerPrefs.GetFloat("HighScore");
        enemySelected = PlayerPrefs.GetInt("Enemy");
        if (hs >= itemCost && enemySelected != enemyId)
        {
            PlayerPrefs.SetInt("Enemy", enemyId);
            ItemText.text = "ON";
            return;
        }
    }
    void CheckIfEnemyActive ()
    {
        hs = PlayerPrefs.GetFloat("HighScore");
        if (hs == 0)
        {
            PlayerPrefs.SetInt("Enemy", 1);
        }
        enemySelected = PlayerPrefs.GetInt("Enemy");
        if (enemySelected == enemyId)
        {
            ItemText.text = "ON";
        } else if (hs >= itemCost && enemySelected != enemyId)
        {
            ItemText.text = "OFF";
        } else
        {
            ItemText.text = itemCost.ToString();
        }
    }
}
