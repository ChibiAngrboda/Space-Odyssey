using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public GameObject cam;
    Rigidbody2D m_rigidbody;
    public float Pous�e = 28f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        m_rigidbody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // cam�ra qui suit un peu mais pas trop
        if (gameObject.transform.position.y >= 0 && gameObject.transform.position.y <= 10)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        }
        

        //controles : 
        if (Input.GetMouseButton(0))
        {
            print("rien que pour toi b�bou l�andre");

            m_rigidbody.AddForce(transform.up, (ForceMode2D)Pous�e);
        }


        /*if (Input.GetMouseButton(1))
        {
            print("yeahhhh");
        }*/
    }
}
