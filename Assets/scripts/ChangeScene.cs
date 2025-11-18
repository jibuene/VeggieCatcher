using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private string selectedScene;

    // Start is called before the first frame update
    void Start()
    {
		  btn.onClick.AddListener(ChangeSceneTrigger);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeSceneTrigger()
    {
      SceneManager.LoadScene(selectedScene);
    }
}
