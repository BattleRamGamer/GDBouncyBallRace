using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    enum colldierType {spawn, despawn }
    Tile tile;

    [SerializeField] private colldierType colliderType;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tile = GetComponentInParent<Tile>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(GameManager.Instance.getPlayerTag))
        {
            switch (colliderType)
            {
                case colldierType.spawn:
                    Instantiate(tile.getTile(), tile.transform.position + new Vector3(0, 0, 15), tile.transform.rotation);
                    return;
                case colldierType.despawn:
                    tile.DestroyTile();
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
