using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
    private int soundEnabled;
    [SerializeField] private Text ItemText;
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(buyItem);

        soundEnabled = PlayerPrefs.GetInt("Sound");
        if (soundEnabled == 1)
        {
            PlayerPrefs.SetInt("Sound", 1);
            ItemText.text = "Sound: ON";
            return;
        } else
        {
            PlayerPrefs.SetInt("Sound", 0);
            ItemText.text = "Sound: OFF";
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void buyItem()
    {
        soundEnabled = PlayerPrefs.GetInt("Sound");
        if (soundEnabled == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            ItemText.text = "Sound: OFF";
            return;
        } else
        {
            PlayerPrefs.SetInt("Sound", 1);
            ItemText.text = "Sound: ON";
            return;
        }
    }
}
