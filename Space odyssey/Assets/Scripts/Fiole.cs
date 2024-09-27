using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour
{
    
    public float StartPosY;
    
    public float rangeMoove;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        StartPosY = gameObject.transform.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y < StartPosY - rangeMoove)
        {
            gameObject.transform.position -= new Vector3(0,1,0) * speed;
        }
        else if (gameObject.transform.position.y > StartPosY + rangeMoove)
        {
            gameObject.transform.position += new Vector3(0,1,0) * speed;
        }
    }
}
