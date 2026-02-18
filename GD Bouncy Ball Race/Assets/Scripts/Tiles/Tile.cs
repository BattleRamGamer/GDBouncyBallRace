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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Instantiate(getTile(), transform.position + new Vector3(0,0,15), transform.rotation);
        Debug.Log(this);
        GameObject.Destroy(this.gameObject);
        
    }

    public GameObject getTile()
    {
        return tileList[Random.Range(0, tileList.Length)].gameObject;
    }
}
