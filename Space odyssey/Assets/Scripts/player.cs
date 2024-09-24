using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public GameObject cam;
    Rigidbody2D m_rigidbody;
    public float thrust = 10f;
    public float stopThrust;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        m_rigidbody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // caméra qui suit un peu mais pas trop
        if (gameObject.transform.position.y >= 0 && gameObject.transform.position.y <= 10)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        }
        

        //controles : 
        if (Input.GetMouseButton(0))
        {
            //print("rien que pour toi bébou léandre");

            m_rigidbody.AddForce(transform.up, (ForceMode2D)thrust);
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_rigidbody.velocity = Vector3.up * -stopThrust;
        }

        else
        {
            //m_rigidbody.velocity = Vector3.zero;
            
        }


        /*if (Input.GetMouseButton(1))
        {
            print("yeahhhh");
        }*/
    }
}
