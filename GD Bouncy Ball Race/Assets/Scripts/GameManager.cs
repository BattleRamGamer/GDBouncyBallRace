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
            Destroy(gameObject);
        }
    }



    public void TriggerDeath()
    {
        // Add death stuff here
    }

}
