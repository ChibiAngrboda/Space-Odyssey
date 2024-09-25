using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D m_rigidbody;
    [Header("Caméra")]
    public GameObject cam;
    public float camShift;
    [Space(5)]
    [Header("Mouvements")]
    public float thrust = 10f;
    public float stopThrust;
    public float speed;
    public float slow;
    public float acceleration;
    [Space(5)]
    [Header("Collectables")]
    public int fioleNB;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        m_rigidbody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // caméra qui suit sur x 
        cam.transform.position = new Vector3(gameObject.transform.position.x + camShift, cam.transform.position.y, cam.transform.position.z);
        // caméra qui suit sur y un peu mais pas trop
        if (gameObject.transform.position.y >= 0 && gameObject.transform.position.y <= 10)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        }
        

        //controles : 
        if (Input.GetMouseButton(0))
        {

           m_rigidbody.AddForce(transform.up, (ForceMode2D)(thrust * Time.fixedDeltaTime));

            // limiter la poussée
            m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, 10f);
        }
        // couper l'inertie du addforce
        if (Input.GetMouseButtonUp(0))
        {
            m_rigidbody.velocity = Vector3.up * -stopThrust;
        }

        // avancée du joueur

        m_rigidbody.AddForce(transform.right, (ForceMode2D)(speed * Time.fixedDeltaTime));
       




    }

    private void FixedUpdate()
    {
        
        gameObject.transform.position += new Vector3(speed, 0, 0);
        speed += acceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fiole")
        {
            Destroy(collision.gameObject);
            fioleNB += 1;
            
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            speed = speed * slow;
        }

    }
}
