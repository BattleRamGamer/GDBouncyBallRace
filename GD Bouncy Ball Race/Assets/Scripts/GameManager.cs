using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    [SerializeField] private const string PLAYER_TAG = "Player";
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI distanceText;

    private GameObject player;
    private GameObject enemy;
    private float enemyDistance;
     
    private int score = 0;
    public int getScore => score;
    public string getPlayerTag => PLAYER_TAG;

    


    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    public Difficulty difficulty;


    public static GameManager Instance;


    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            // I don't actually care about keeping this instance the only one.
            // When loading a new scene, the GameManager of the previous scene is still Instance
            // even though it doesn't really exist anymore.
            // This would be a problem if this script has a reference to an object in the scene (like UI)
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }

    public void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        player = GameObject.FindWithTag("Player");
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        enemyDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
        distanceText.text = "Barrier Distance: " + (int)enemyDistance;
    }



    public void TriggerDeath()
    {
        // Add death stuff here

        // EnemyChase already disables the player's controls because GameManager doesn't keep track of the player's position yet
        // Once the distance UI thing is implemented, add the following (and remove it from EnemyChase):
        // player.GetComponent<PlayerMovement>().Die();

        
        GameOver.Instance.DoGameOver(score); 
    }

    public void addScore(int addBy)
    {
        score += addBy;
        scoreText.text = "Score: " + score;
    }

}
