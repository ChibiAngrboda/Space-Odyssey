using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

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
    public int bonusCD;
    public GameObject powerUP;
    private Transform Shield;
    public bool IsShieldActive = false;
    [Space(5)]
    [Header("UI")]
    public TMP_Text ScoreText;
    public GameObject Alien;
    public TMP_Text DistanceText;
    public float distance;
    public RectTransform Indicateur;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        Shield = transform.Find("Shield");
        m_rigidbody = GetComponent <Rigidbody2D>();
        Alien = GameObject.Find("Alien");
        //Indicateur = GameObject.Find("Indicateur");
    }

    // Update is called once per frame
    void FixedUpdate()
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

            m_rigidbody.AddForce(transform.up, (ForceMode2D)(thrust));

            // limiter la poussée
            m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, 10f);
        }
        // couper l'inertie du addforce
        if (Input.GetMouseButtonUp(0))
        {
            m_rigidbody.velocity = Vector3.up * -stopThrust;
        }


        // tue le joueur si il tombe 

        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }


        gameObject.transform.position += new Vector3(speed, 0, 0);
        speed += acceleration;

        // score

        ScoreText.text = "Samples collected = " + fioleNB.ToString();

        // affiche distance alien
        distance = gameObject.transform.position.x - Alien.transform.position.x;
        int roundedDistance = Mathf.RoundToInt(distance);
        DistanceText.text = roundedDistance.ToString() + " m";


        /*
        Transform playerPos = gameObject.transform;
        Camera camera = Camera.main;
        Vector3 playerScreenPos = camera.WorldToScreenPoint(playerPos.position);
        Indicateur.position = new Vector3(Indicateur.position.x, playerScreenPos.y, Indicateur.position.z);
        Debug.Log("Player Position: " + playerPos.position + " Indicator Position: " + Indicateur.position);
        */


        if (bonusCD >= 25)
        {
            //int randomNB = Random.Range(0, 11);
            Instantiate(powerUP, new Vector3(gameObject.transform.position.x + 20, gameObject.transform.position.y, powerUP.transform.position.z), new Quaternion(0,0,0,0));
            bonusCD = 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fiole")
        {
            Destroy(collision.gameObject);
            fioleNB += 1;
            bonusCD += 1;
            speed += 0.01f;
        }
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(gameObject);
            

        }
        if (collision.gameObject.tag == "PowerUP")
        {
            
            Destroy(collision.gameObject);
            if (IsShieldActive == false)
            {
                Shield.gameObject.SetActive(true);
                IsShieldActive = true;
            }
            

        }
    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);

            if (IsShieldActive == false)
            {
                speed = speed * slow;
            }
            else if (IsShieldActive == true)
            {
                Shield.gameObject.SetActive (false);
                IsShieldActive = false;
             
            }
            
        }

    }
}
