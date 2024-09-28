using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelSegments; 
    public Transform player; 
    public float spawnDistance = 20f; 
    private float lastSegmentEndX;
    public GameObject Spawner;

    void Start()
    {
        //Spawner = GameObject.Find("Spawner");
        lastSegmentEndX = 48f; 
        SpawnSegment(); 
    }

    void Update()
    {
       
        if (player.position.x >= lastSegmentEndX - spawnDistance)
        {
            SpawnSegment();
        }

        // Détruire les segments passés
        foreach (GameObject segment in GameObject.FindGameObjectsWithTag("Segment"))
        {
            if (segment.transform.position.x < player.position.x - 100f) 
            {
                Destroy(segment);
            }
        }
    }

    void SpawnSegment()
    {
        // Choisir un segment 
        GameObject segment = Instantiate(levelSegments[Random.Range(0, levelSegments.Length)]);

        
        float segmentWidth = 50f;
        segment.transform.position = new Vector3(lastSegmentEndX /*+ segmentWidth /2*/ , 0 , 0); 

        lastSegmentEndX += segmentWidth; // Mettre à jour la position de la fin du dernier segment

        print("Segment spawned at: " + segment.transform.position); 
    }

  
}
