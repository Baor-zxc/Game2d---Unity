using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRap3 : MonoBehaviour
{
    public GameObject player;
    public GameObject fire;
    public float positionT;
    float count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        count += Time.deltaTime;       
        if(player.transform.position.x>=transform.position.x+positionT){
            
            if(count>=2){
                GameObject att = Instantiate(fire,transform.position, Quaternion.identity);
                count = 0;
            }
           
        }
    }
}
