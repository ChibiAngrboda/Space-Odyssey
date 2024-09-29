using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

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
    public float Score;
    public GameObject Alien;
    public TMP_Text DistanceText;
    public float distance;
    public RectTransform Indicateur;
    public Slider SliderShield;

    [Space(5)]
    [Header("Appear")]
    public GameObject bird;
    public Transform UpFlame;
    public Transform BackFlame1;
    public Transform BackFlame2;
    public Transform BackFlame3;
    public GameObject asteroidBreak;

    [Space(5)]
    [Header("Audios")]
    public GameObject AudioBirdDead;
    public GameObject AudioRock;
    public GameObject AudioShield;  
    public GameObject AudioShield2;
    public AudioSource Pulse;
    public GameObject AudioFioles;

    [Space(5)]
    [Header("Lights")]
    public Light2D lightFire;
    public float minIntensity;
    public float maxIntensity;
    public float fluctuationSpeed;
    private float time;
    //public float offset;
    // Start is called before the first frame update
    void Start()
    {
        Pulse = transform.Find("pulseAudio").GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera");
        Shield = transform.Find("Shield");
        UpFlame = transform.Find("UpFire");
        BackFlame1 = transform.Find("BackFire1");
        BackFlame2 = transform.Find("BackFire2");
        BackFlame3 = transform.Find("BackFire3");
        m_rigidbody = GetComponent <Rigidbody2D>();
        Alien = GameObject.Find("Alien");
        SliderShield.value = bonusCD;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime * fluctuationSpeed;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(time) + 1) / 2);
        lightFire.intensity = intensity;

        // caméra qui suit sur x 
        cam.transform.position = new Vector3(gameObject.transform.position.x + camShift, cam.transform.position.y, cam.transform.position.z);
        // caméra qui suit sur y un peu mais pas trop
        if (gameObject.transform.position.y >= 0 && gameObject.transform.position.y <= 10)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        }

        SliderShield.value = bonusCD;
        //controles : 
        if (Input.GetMouseButton(0))
        {
            Pulse.Play();
            m_rigidbody.AddForce(transform.up, (ForceMode2D)(thrust));
            UpFlame.gameObject.SetActive(true);
            m_rigidbody.gravityScale = 1;

            // limiter la poussée
            m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, 10f);
        }
        else 
        { 
            Pulse.Stop();
            UpFlame.gameObject.SetActive(false);
            m_rigidbody.gravityScale = 3;
        }
        


        // tue le joueur si il tombe 

        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }


        gameObject.transform.position += new Vector3(speed, 0, 0);
        speed += acceleration;

        // score
        Score = gameObject.transform.position.x;
        int roundedScore = Mathf.RoundToInt(Score);
        ScoreText.text = "Score = " + roundedScore.ToString();

        // affiche distance alien
        distance = gameObject.transform.position.x - Alien.transform.position.x;
        int roundedDistance = Mathf.RoundToInt(distance);
        DistanceText.text = roundedDistance.ToString() + " m";


        /*
        Transform playerPos = gameObject.transform;
        Camera camera = Camera.main;
        Vector3 playerScreenPos = RectTransformUtility.WorldToScreenPoint(camera, (Vector2)playerPos.position);

        Indicateur.anchoredPosition= new Vector3(Indicateur.position.x, playerScreenPos.y - offset, Indicateur.position.z);
        //healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;
        //Indicateur.anchoredPosition = (Vector2)playerScreenPos - Indicateur.sizeDelta / 2f;

       // Debug.Log("Player Position: " + playerPos.position + " Indicator Position: " + Indicateur.position);
        */

        if (speed < 0.3f)
        {
            gameObject.GetComponent<AudioSource>().volume = 0.02f;
            BackFlame1.gameObject.SetActive(true);
            BackFlame2.gameObject.SetActive(false);
            BackFlame3.gameObject.SetActive(false);
            lightFire.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (speed < 0.4f)
        {
            gameObject.GetComponent<AudioSource>().volume = 0.08f;
            BackFlame1.gameObject.SetActive(false);
            BackFlame2.gameObject.SetActive(true);
            BackFlame3.gameObject.SetActive(false);
            lightFire.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.1f;
            BackFlame1.gameObject.SetActive(false);
            BackFlame2.gameObject.SetActive(false);
            BackFlame3.gameObject.SetActive(true);
            lightFire.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        }

        if (bonusCD >= 10)
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
            Instantiate(AudioFioles, transform);
            Destroy(collision.gameObject);
            fioleNB += 1;
            bonusCD += 1;
            speed += 0.01f;
        }
        if (collision.gameObject.tag == "FioleBIG")
        {
            Instantiate(AudioFioles, transform);
            Destroy(collision.gameObject);
            fioleNB += 1;
            bonusCD += 2;
            speed += 0.04f;
        }
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(gameObject);
            int playerScore = Mathf.RoundToInt(Score); ;
            CheckAndSaveScore(playerScore);
            SceneManager.LoadScene("Menu");

        }
        if (collision.gameObject.tag == "PowerUP")
        {

            
            Destroy(collision.gameObject);
            if (IsShieldActive == false)
            {
                Instantiate(AudioShield2, transform);
                Shield.gameObject.SetActive(true);
                IsShieldActive = true;
            }
            

        }
        
            if (collision.gameObject.tag == "rock")
        {
            Destroy(collision.gameObject);
            AudioRock.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.8f);
            Instantiate(AudioRock, transform);
           
            if (IsShieldActive == false && speed * slow >= 0.1f)
            {
                speed = speed * slow;
            }
            else if (IsShieldActive == true)
            {
                Instantiate(AudioShield, transform);
                Shield.gameObject.SetActive(false);
                IsShieldActive = false;

            }

        }
        if (collision.gameObject.tag == "asteroid")
        {
            Quaternion rotation = collision.gameObject.transform.rotation;
            Vector3 pos = collision.gameObject.transform.position;
            
            Instantiate(asteroidBreak, pos, rotation);

            
            AudioRock.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.8f);
            Instantiate(AudioRock, transform);
            Destroy(collision.gameObject);

            if (IsShieldActive == false && speed * slow >= 0.1f)
            {
                speed = speed * slow;
            }
            else if (IsShieldActive == true)
            {
                Instantiate(AudioShield, transform);
                Shield.gameObject.SetActive(false);
                IsShieldActive = false;

            }

        }

        if (collision.gameObject.tag == "bird")
        {
            Destroy(collision.gameObject);
            AudioBirdDead.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
            Instantiate(AudioBirdDead, transform);

            if (IsShieldActive == false && speed * slow >= 0.1f)
            {
                speed = speed * slow;
            }
            else if (IsShieldActive == true)
            {
                Instantiate(AudioShield, transform);
                Shield.gameObject.SetActive(false);
                IsShieldActive = false;

            }

        }
    }

    
    /*
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

    }*/

    public void CheckAndSaveScore(int playerScore)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        int lastScore = PlayerPrefs.GetInt("lastScore",0);
        int SCORE = Mathf.RoundToInt(Score);
        PlayerPrefs.SetInt("lastScore", SCORE);
        if (playerScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", playerScore);
            PlayerPrefs.Save();
        }
    }


}
