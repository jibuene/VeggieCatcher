using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hardmode : MonoBehaviour
{
    public Text HardModeText;
    private float hardEnabled;
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(hardmode);
        hardEnabled = PlayerPrefs.GetFloat("Hardmode");
        if (hardEnabled == 1)
        {
            HardModeText.text = "Hard mode: ON";
        } else
        {
            HardModeText.text = "Hard mode: OFF";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void hardmode()
    {
        if (hardEnabled != 1)
        {
            PlayerPrefs.SetFloat("Hardmode", 1);
            HardModeText.text = "Hard mode: ON";
            hardEnabled = 1;
        } else
        {
            PlayerPrefs.SetFloat("Hardmode", 0);
            HardModeText.text = "Hard mode: OFF";
            hardEnabled = 0;
        }
    }
}
