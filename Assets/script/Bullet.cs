using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rigidbody2D;
    Collider2D collider2D;
    bool isRight ;
    float speed=5f;
    public AudioClip soundDie,soundMagic;
    AudioSource audioSource;

    float dem=0;
    // Start is called before the first frame update
    void Start()
    {
        isRight = player_Knight.ChuyenQua.isRight; 
        rigidbody2D =  GetComponent<Rigidbody2D>();
        collider2D =  GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        audioSource.PlayOneShot(soundMagic);
        if(isRight == true){
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }else{
            transform.Translate(Time.deltaTime * -speed, 0, 0);
        }
        if(dem==3){
            Destroy(gameObject);
            dem=0;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
      
        // if(other.gameObject.CompareTag("land")){
            
        //     speed=0;
        //     dem++;
        //     rigidbody2D.AddForce(Vector3.up * 1f, ForceMode2D.Impulse);
           
        // }
        
        // if(other.gameObject.CompareTag("player")){
        //   Destroy(gameObject);
        // }

        // if(other.gameObject.CompareTag("monters")){
        
        //  Destroy(gameObject);
        // }

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.gameObject.CompareTag("monters")){
        //  string name = other.attachedRigidbody.name;
        //  Destroy(GameObject.Find(name));
        
         Destroy(gameObject);
        }

       
    }


      
}
