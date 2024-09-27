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
    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score : " + bestScore;
        int lastScore = PlayerPrefs.GetInt("lastScore", 0);
        lastScoreText.text = "Last Score : " + lastScore;
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
