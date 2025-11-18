using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHs : MonoBehaviour
{
    [SerializeField] private Text HSText;
    private float previousHs;

    // Start is called before the first frame update
    void Start()
    {
        previousHs = PlayerPrefs.GetFloat("HighScore");
        HSText.text = HSText.text + previousHs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
