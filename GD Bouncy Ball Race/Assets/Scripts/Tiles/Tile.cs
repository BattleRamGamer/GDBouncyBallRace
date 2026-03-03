using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] private int tileDifficulty;
    [SerializeField] private static int delayTime = 5;
    [SerializeField] private Collider despawnTriggerCollider;
    
    public int getDifficulty => tileDifficulty;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public GameObject getTile()
    {
        return TileManager.Instance.GetRandomTile();
    }

    public void DestroyTile()
    {
        Destroy(this.gameObject);
    }
    
}
