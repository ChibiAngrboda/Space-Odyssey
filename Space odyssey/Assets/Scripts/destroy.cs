using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float speed = 1f; // Vitesse de mouvement
    public float rotationSpeed = 20f; // Vitesse de rotation
    public GameObject player;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        float angle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "asteroid")
        {
            transform.position += (Vector3)(movementDirection * speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
             


        if (gameObject.transform.position.x < player.transform.position.x - 10) 
        { 
            Destroy(gameObject); 
        }
    }
}
