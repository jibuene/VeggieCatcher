using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class reachedGoal : MonoBehaviour
{
    [SerializeField] private Text GoalText;
    [SerializeField] private Text DeathText;
    [SerializeField] ParticleSystem smokeEffect;
    private double goalCounter;
    private double secondCounter;
    private int score = 0;
    private bool doublePoints;
    private int points = 1;
    private int superAttackSpawned = 0;
    private GameObject[] stackingCubes;
    private GameObject enemy;
    private float rangeX;
    private float rangeY;
    private float previousHs;
    Vector3 mousePosition;
    private bool startedDragging;
    [SerializeField] GameObject StartFloor;
    [SerializeField] AudioSource friendlySpawnSound;
    [SerializeField] AudioSource enemySpawnSound;
    [SerializeField] AudioSource soundtrack;
    private int playerPrefEnemy;
    private float spawnTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        GoalText.text = "Move player to start";
    }

    // Update is called once per frame
    void Update()
    {
        playerPrefEnemy = PlayerPrefs.GetInt("Enemy");
        switch(playerPrefEnemy) 
        {
        case 1:
            enemy = GameObject.Find("Enemy-Chocolate");
            break;
        case 2:
            enemy = GameObject.Find("Enemy-Cake");
            break;
        case 3:
            enemy = GameObject.Find("Enemy-Whale");
            break;
        default:
            enemy = GameObject.Find("Enemy-Chocolate");
            break;
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartGameOnMove();
        stackingCubes = GameObject.FindGameObjectsWithTag("StackingObject");
        if (DeathText.text != "YOU LOST! RESTART?" && startedDragging)
        {
            goalCounter += Time.deltaTime;
            secondCounter += Time.deltaTime;
            if (spawnTimer > 0.5f && secondCounter > 1)
            {
                secondCounter = 0;
                spawnTimer -= 0.02f;
                soundtrack.pitch += 0.01f;
            }
        }
        if (goalCounter > spawnTimer)
        {
            goalCounter = 0;
            AddCoin();
            rangeX = Random.Range(-1.5f, 1.7f);
            rangeY = Random.Range(3.2f, 4.8f);
            float randValue = Random.value;
            if (randValue < .26f) // % of the time
            {
                Instantiate(stackingCubes[0], new Vector3(rangeX, rangeY, 499), Quaternion.identity);
                friendlySpawnSound.Play();
                superAttackSpawned = 0;
            } else if(randValue > .26f && randValue < .52f) 
            {
                Instantiate(stackingCubes[1], new Vector3(rangeX, rangeY, 499), Quaternion.identity);
                friendlySpawnSound.Play();
                superAttackSpawned = 0;
            } else if(randValue > .52f && randValue < .80f) 
            {
                Instantiate(stackingCubes[2], new Vector3(rangeX, rangeY, 499), Quaternion.identity);
                friendlySpawnSound.Play();
                superAttackSpawned = 0;
            } else if ((randValue > .80f && randValue < .86f) && superAttackSpawned != 1)
            {
                Instantiate(enemy, new Vector3(rangeX, rangeY, 499), Quaternion.identity);
                Instantiate(smokeEffect, new Vector3(rangeX, rangeY, 500), transform.rotation);

                rangeX = Random.Range(-1.5f, 1.7f);
                rangeY = Random.Range(3.2f, 4.8f);
                Instantiate(enemy, new Vector3(rangeX, rangeY, 499), Quaternion.identity);

                enemySpawnSound.Play();
                superAttackSpawned = 1;
            }
            else 
            {
                Instantiate(enemy, new Vector3(rangeX, rangeY, 499), Quaternion.identity);
                enemySpawnSound.Play();
                superAttackSpawned = 0;
            }
            Instantiate(smokeEffect, new Vector3(rangeX, rangeY, 500), transform.rotation);
            score += 1;
            GoalText.text = "Score: " + score.ToString();
        }
        NewHighScore();
        if (stackingCubes.Length > 6)
        {
            // KILL
            DestroyFirstClone();
        }
    }
    void AddCoin ()
    {
        doublePoints = PlayerPrefs.GetInt("2xPoints") == 1;
        if (doublePoints)
        {
            points = 2;
        }

        PlayerPrefs.SetFloat("Coins", (PlayerPrefs.GetFloat("Coins") + points));
    }
    void DestroyFirstClone ()
    {
        Destroy(stackingCubes[3], 0);
    }
    void NewHighScore ()
    {
        previousHs = PlayerPrefs.GetFloat("HighScore");
        if (score > previousHs)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }
    }
    void StartGameOnMove ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                startedDragging = true;
                StartFloor.transform.position = new Vector2(0,-150);
                GoalText.text = "Score: " + score.ToString();
            }
        }
    }
}
