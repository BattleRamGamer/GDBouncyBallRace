using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]public Tile[] tileList;
    [SerializeField] private int tileDifficulty;
    [SerializeField] private static int delayTime = 5;
    [SerializeField] private Collider despawnTriggerCollider;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public GameObject getTile()
    {
        return tileList[Random.Range(0, tileList.Length)].gameObject;
    }

    public void DestroyTile()
    {
        Destroy(this.gameObject);
    }
    
}
