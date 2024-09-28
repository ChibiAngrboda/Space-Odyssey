using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonGestion : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Music;
    public AudioSource Pulse;

   
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScène");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Music.GetComponent<AudioSource>().volume = 0.05f;
        //Pulse = transform.Find("pulseAudio").GetComponent<AudioSource>();
        //Pulse.volume = 0.01f;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Music.GetComponent<AudioSource>().volume = 0.2f;
       // Pulse = transform.Find("pulseAudio").GetComponent<AudioSource>();
        //Pulse.volume = 0.3f;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
