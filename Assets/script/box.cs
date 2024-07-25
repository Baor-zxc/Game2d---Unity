using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    public GameObject boxRandom;
    public GameObject coin,heal,bullet;
    
    //public GameObject monters;

    

    int count =0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(count==5){
        //     Destroy(gameObject);
        //     GameObject att = Instantiate(boxRandom,transform.position, Quaternion.identity);
        // }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if(other.gameObject.CompareTag("player")){
           
        //     count++;
           
        // }
        if(other.gameObject.CompareTag("player")){
           
           // GameObject att = Instantiate(boxRandom,transform.position, Quaternion.identity);
            int randomNumber = Random.Range(1,3);
            
            // ranom vat pham
            if(randomNumber==1){
                Vector3 positiona=transform.position;
                positiona.y+=0.7f;
                Instantiate(coin,positiona, Quaternion.identity);
            }else if(randomNumber==2){
                Vector3 positiona=transform.position;
                positiona.y+=0.9f;
                Instantiate(bullet,positiona, Quaternion.identity);
            }else{
                Vector3 positiona=transform.position;
                positiona.y+=0.9f;
                Instantiate(heal,positiona, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        

    }

    public static box ChuyenQua;

    void Awake()
    {
      ChuyenQua =this;
    }
    
}
