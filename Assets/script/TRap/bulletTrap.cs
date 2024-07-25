using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public float dan;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * dan, 0, 0);
        Destroy(gameObject,5f);
        
       
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("player")){
            Destroy(gameObject);
        }
    }
}
