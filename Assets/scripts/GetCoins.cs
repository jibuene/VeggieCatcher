using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoins : MonoBehaviour
{
    [SerializeField] private Text CoinsText;
    private float coins;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetFloat("Coins");
        CoinsText.text = "Coins: " + coins;
    }
}