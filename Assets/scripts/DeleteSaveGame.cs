using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(del);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void del()
    {
        PlayerPrefs.DeleteAll();
    }
}
