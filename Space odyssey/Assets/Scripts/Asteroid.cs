using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 1f; // Vitesse de mouvement
    public float rotationSpeed = 20f; // Vitesse de rotation

    private Vector2 movementDirection;

    void Start()
    {
        // Choisir une direction aléatoire
        float angle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    void Update()
    {
        // Déplacer l'astéroïde
        transform.position += (Vector3)(movementDirection * speed * Time.deltaTime);

        // Faire tourner l'astéroïde
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Inverser la direction
            movementDirection = -movementDirection.normalized;
        }
    }
    }
