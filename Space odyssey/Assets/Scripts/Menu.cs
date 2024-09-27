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
    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score : " + bestScore;
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
