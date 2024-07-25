using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject player;
    public float positionMinY,positionMaxY;
    float positionMinX,positionMaxX;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        positionMaxX=gameObject.transform.position.x+0.5f;
        positionMinX=gameObject.transform.position.x-0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>=positionMinX&&player.transform.position.x<=positionMaxX){
            if(player.transform.position.y >= positionMinY && player.transform.position.y<=positionMaxY){
                rigidbody2D.gravityScale=1f;
            }
           
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("player")){
            
        }
    }
}
