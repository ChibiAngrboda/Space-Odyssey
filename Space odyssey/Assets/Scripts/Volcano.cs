using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    public GameObject rock;
    public float cooldown;
    public float baseCD;
    public GameObject player;
    public float playerDistance;
    public GameObject spit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        
        cooldown -= 1;
        if (cooldown <= 0 && playerDistance>5)
        {
            gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.7f, 1.5f);
            gameObject.GetComponent<AudioSource>().Play();
            GameObject spitToDestroy = Instantiate(spit, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, 0), new Quaternion(0, 0, 0, 0));
            //spitInstantiate(spitToDestroy);

           Instantiate(rock,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + 2.5f, 0), new Quaternion(0,0,0,0));
            cooldown += baseCD;
        }
        /*
        IEnumerator spitInstantiate(GameObject cible)
        {
            
            yield return new WaitForSeconds(0.5f);
            Destroy(cible);
        }*/
    }
}
