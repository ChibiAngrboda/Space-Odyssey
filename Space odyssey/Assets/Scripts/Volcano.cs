using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    public GameObject rock;
    public float cooldown;
    public float baseCD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown -= 1;
        if (cooldown <= 0)
        {
            Instantiate(rock,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + 5, 0), new Quaternion(0,0,0,0));
            cooldown += baseCD;
        }
    }
}
