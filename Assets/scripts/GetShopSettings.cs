using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GetShopSettings : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private ColorGrading _cg;
    [SerializeField] private Text DeathText;
    private bool hasRun = false;
    private int playerPrefPlayer;
    private int soundEnabled;
    [SerializeField] AudioSource soundtrack;

    // Start is called before the first frame update
    void Start()
    {
        soundEnabled = PlayerPrefs.GetInt("Sound");
        if (soundEnabled == 1)
        {
            soundtrack.volume = 0.124f;
        } else
        {
            soundtrack.volume = 0f;
        }

        playerPrefPlayer = PlayerPrefs.GetInt("Player");
        if (playerPrefPlayer == 0)
        {
            playerPrefPlayer = 1;
        }
        Instantiate(GameObject.Find("CatcherLvL" + playerPrefPlayer), new Vector3(0, 0, 443), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (DeathText.text == "YOU LOST! RESTART?" && !hasRun)
        {
            StartCoroutine(DeathScreen());
        }
    }

    private IEnumerator DeathScreen()
    {
        hasRun = true;
        for (int i = 0; i < 50; i++)
        {
            _postProcessVolume.profile.TryGetSettings(out _cg);
            _cg.saturation.value -= 2;

            yield return new WaitForSeconds(0.2f);
        }
    }
}
