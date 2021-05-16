using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 1;

    public int visibleTiles = 4;

    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
       for (int i = 0; i < visibleTiles; i++) 
       {
           SpawnTile(Random.Range(0,tilePrefabs.Length));
       }
    }

    void Update()
    {
        if (playerTransform.position.z -40 > zSpawn - (visibleTiles * tileLength))
        {
            DeleteTile();
            SpawnTile(Random.Range(0,tilePrefabs.Length));
            
        }
    }
    public void SpawnTile(int tileIndex) 
    {
        GameObject gameobject = Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(gameobject);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        
    }
}