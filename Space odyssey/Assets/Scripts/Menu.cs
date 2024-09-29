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
        else { next.SetActive(false); }
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
        Application.Quit();
    }

    
}
