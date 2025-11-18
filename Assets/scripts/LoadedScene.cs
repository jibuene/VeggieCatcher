using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadedScene : MonoBehaviour
{
    public string eventSystemName;
    // Start is called before the first frame update
     void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EventSystem eventSystem = GameObject.Find(eventSystemName).GetComponent<EventSystem>();
        eventSystem.enabled = true;
    }
    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
