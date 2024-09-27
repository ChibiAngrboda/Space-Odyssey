using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        float randomSPD = Random.Range(0.01f, 0.05f);
        speed = randomSPD;
    }
    void FixedUpdate()
    {
        
        gameObject.transform.position += new Vector3(-5 * speed, 0,0);
    }
}
