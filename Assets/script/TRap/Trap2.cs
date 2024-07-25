using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    public GameObject player;
    public float postionX;
    public float postionY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("player")){
            Destroy(gameObject);
        }
    }
}
