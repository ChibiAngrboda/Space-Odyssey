using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector3(Random.Range(-5,5),Random.Range(2,5),0));
        rb.AddForce(transform.up * 5);
    }

    
}
