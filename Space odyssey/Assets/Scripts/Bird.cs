using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    public GameObject player;
    

    private void Start()
    {
        player = GameObject.Find("Player");
        float randomSPD = Random.Range(0.01f, 0.05f);
        speed = randomSPD;
    }
    void FixedUpdate()
    {
        
        gameObject.transform.position += new Vector3(-5 * speed, 0,0);

        if (gameObject.transform.position.x < player.transform.position.x - 8)
        {
            
            Destroy(gameObject);
        }
    }
}
