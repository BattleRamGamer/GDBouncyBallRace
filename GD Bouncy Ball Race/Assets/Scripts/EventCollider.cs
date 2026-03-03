using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class EventCollider : MonoBehaviour
{
    enum colldierType {spawn, despawn, death}
    Tile tile;
    private bool nextTileSpawned = false;

    [SerializeField] private colldierType colliderType;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tile = GetComponentInParent<Tile>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(GameManager.Instance.getPlayerTag) && !nextTileSpawned)
        {
            switch (colliderType)
            {
                case colldierType.spawn:
                    Instantiate(tile.getTile(), tile.transform.position + new Vector3(0, 0, 15), tile.transform.rotation);
                    nextTileSpawned = true;
                    GameManager.Instance.addScore(tile.getDifficulty);
                    return;
                case colldierType.despawn:
                    tile.DestroyTile();
                    return;
                case colldierType.death:
                    GameManager.Instance.TriggerDeath();
                    Debug.Log("DeathColliderHit");
                    return;
                default: return;
            }
            
        }
            

    }

    void SpawnNextTile()
    {

    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
