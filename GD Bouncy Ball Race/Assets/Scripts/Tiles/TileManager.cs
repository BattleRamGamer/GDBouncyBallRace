using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private bool enableDynamicDifficulty;

    [SerializeField] 
    private GameObject[] tileList;

    [SerializeField] private GameObject[] easyTiles;
    [SerializeField] private GameObject[] mediumTiles;
    [SerializeField] private GameObject[] hardTiles;

    public static TileManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetRandomTile()
    {
        if (enableDynamicDifficulty) return GetRandomDifficultyTile();
        return tileList[Random.Range(0, tileList.Length)];
    }

    private GameObject GetRandomDifficultyTile()
    {

        switch (GameManager.Instance.difficulty)
        {
            case GameManager.Difficulty.Easy: 
                return easyTiles[Random.Range(0, easyTiles.Length)];
                
            case GameManager.Difficulty.Medium: 
                return mediumTiles[Random.Range(0, mediumTiles.Length)];

            case GameManager.Difficulty.Hard: 
                return hardTiles[Random.Range(0, hardTiles.Length)];

        }


        return tileList[Random.Range(0, tileList.Length)];
    }


}
