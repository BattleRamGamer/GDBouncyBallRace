using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private const string PLAYER_TAG = "Player";

    public string getPlayerTag => PLAYER_TAG;





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



    public void TriggerDeath()
    {
        // Add death stuff here

        // EnemyChase already disables the player's controls because GameManager doesn't keep track of the player's position yet
        // Once the distance UI thing is implemented, add the following (and remove it from EnemyChase):
        // player.GetComponent<PlayerMovement>().Die();

        GameOver.Instance.DoGameOver(); // PHILLIP ADD SCORE INT HERE (see line below)
        // GameOver.Instance.DoGameOver(score); 
    }

}
