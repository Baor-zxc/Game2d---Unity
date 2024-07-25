using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    
    public GameObject coineff;
    Collider2D collider2D;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        collider2D= GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("player")){
            Destroy(gameObject);
            GameObject coin_effects = Instantiate (coineff,transform.position,transform.rotation);
            Destroy(coin_effects,2f);
        }
        if(gameObject.CompareTag("land")){
            collider2D.isTrigger=true;
            rigidbody2D.gravityScale=0;
        }
    }
}
