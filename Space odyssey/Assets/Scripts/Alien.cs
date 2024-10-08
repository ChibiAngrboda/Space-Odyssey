using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float acceleration;
    public AudioSource sfx;
    public bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position += new Vector3(speed, 0, 0);
        speed += acceleration;
        
        if (gameObject.transform.position.x >= player.transform.position.x - 7 && wait == false)
        {
            sfx.Play();
            wait = true;
        }
        if (gameObject.transform.position.x < player.transform.position.x - 10 &&wait == false)
        {

            wait = false;
        }
    }


}
