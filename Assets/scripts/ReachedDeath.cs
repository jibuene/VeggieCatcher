using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReachedDeath : MonoBehaviour
{
    private PolygonCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Button btn;
    [SerializeField] private Text DeathText;
    private GameObject[] stackingObjects;
    private float previousHs;
    private GameObject[] enemyObject;
    private int playerPrefEnemy;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<PolygonCollider2D>();
		btn.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
        enemyGrounded();
        StartCoroutine(CheckIfDead());
    }

    IEnumerator CheckIfDead()
    {
        if (isGrounded())
        {
            yield return new WaitForSeconds (0.2f);
            if (isGrounded())
            {
                DeathText.text = "YOU LOST! RESTART?";
            }
        }
    }

    void restart () {
        if (DeathText.text != "YOU LOST! RESTART?")
        {
            return;
        }
        previousHs = PlayerPrefs.GetFloat("HighScore");
        stackingObjects = GameObject.FindGameObjectsWithTag("StackingObject");
        
        if ((stackingObjects.Length - 1) > previousHs)
        {
            PlayerPrefs.SetFloat("HighScore", (stackingObjects.Length - 1));
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    void enemyGrounded()
    {
        LayerMask deathZone = LayerMask.GetMask("DeathZone");
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, deathZone);

        // Get enemy
        playerPrefEnemy = PlayerPrefs.GetInt("Enemy");
        switch(playerPrefEnemy) 
        {
        case 1:
            enemy = GameObject.Find("Enemy-Chocolate(Clone)");
            break;
        case 2:
            enemy = GameObject.Find("Enemy-Cake(Clone)");
            break;
        case 3:
            enemy = GameObject.Find("Enemy-Whale(Clone)");
            break;
        default:
            enemy = GameObject.Find("Enemy-Chocolate(Clone)");
            break;
        }
        if (raycastHit.collider != null && enemy)
        {
            Destroy(enemy, 0);
        }
    }
}
