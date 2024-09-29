using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //public TMPro bestScoreTxt; 
    public TMP_Text bestScoreText;
    public TMP_Text lastScoreText;
    public Button Play;
    public AudioSource playSfx;
    public GameObject next;
    public bool isVolletUp = false;
    public GameObject vollet;
    public float speedVollet;
    public GameObject titre;
    public GameObject bestScoreDev;
    public GameObject OpenTexts;
    public GameObject stats;
    public TMP_Text bestScoreTextSTATS;
    public TMP_Text lastScoreTextSTATS;
    public TMP_Text maxSpeedTextSTATS;
    public TMP_Text birdKilledTextSTATS;
    public TMP_Text rockDestroyedTextSTATS;
    public TMP_Text boostCollectedTextSTATS;
    private void Start()
    {
        next = GameObject.Find("next ?...");
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Dive : "+ /*"\n" +*/ bestScore;
        int lastScore = PlayerPrefs.GetInt("lastScore", 0);
        lastScoreText.text = "Last Dive : "+ /*"\n" +*/ lastScore;
        Play.onClick.AddListener(PlaySound);
        if(PlayerPrefs.GetInt("BestScore",0) >= 2679)
        {
            next.SetActive(true);
        }
        

        int maxSpeed = PlayerPrefs.GetInt("maxSpeed", 0);
        int rockDestroyed = PlayerPrefs.GetInt("rockDestroyed", 0);
        int birdKilled = PlayerPrefs.GetInt("birdKilled", 0);
        int boostCollected = PlayerPrefs.GetInt("boostCollected", 0);
        bestScoreTextSTATS.text = "Best Dive : " + /*"\n" +*/ bestScore;
        lastScoreTextSTATS.text = "last dive : " + lastScore;
        maxSpeedTextSTATS.text = "max speed : " + maxSpeed;
        rockDestroyedTextSTATS.text = "rocks destroyed : " + rockDestroyed;
        birdKilledTextSTATS.text = "birds killed : " + birdKilled;
        boostCollectedTextSTATS.text = "boost collected : " + boostCollected;

    }
    private void FixedUpdate()
    {
        
        if (isVolletUp == true) 
        {
            OpenTexts.SetActive(true);
            //lastScoreText.enabled = true;
            //bestScoreText.enabled = true;
            titre.SetActive(true);
            bestScoreDev.SetActive(true);
            
        }
        else if(isVolletUp == false)
        {
            OpenTexts.SetActive(false);
            titre.SetActive(false);
            bestScoreDev.SetActive(false);
            //lastScoreText.enabled = false;
            //bestScoreText.enabled = false;

        }
        if (isVolletUp == false && vollet.transform.position.y >= 0.23f)
        {
            vollet.transform.position += new Vector3(0, -1 * speedVollet, 0);
        }
        else if (isVolletUp == true && vollet.transform.position.y <= 11)
        {
            vollet.transform.position += new Vector3(0, 1 * speedVollet, 0);
        }
    }

    void PlaySound()
    {
        playSfx.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScène");
    }

    public void QuitGame()
    {
        isVolletUp = !isVolletUp;
        //Application.Quit();
    }

    
}
