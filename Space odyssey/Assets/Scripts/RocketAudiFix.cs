using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudiFix : MonoBehaviour
{
   

    void Update()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<AudioSource>().Stop();
        }
        else if (Time.timeScale == 1) { GetComponent<AudioSource>().Play(); }
    }
}
