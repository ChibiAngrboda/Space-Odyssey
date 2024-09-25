using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody2D rb;
    
   
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // force aléatoire 
            Vector2 force = new Vector2(Random.Range(-7f, 7f), Random.Range(8f, 14f));
            rb.AddForce(force, ForceMode2D.Impulse);
            
        }
        

    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

}
