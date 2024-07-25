using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monter_ork2 : MonoBehaviour
{
    public float left, right ;
    bool isRight;
    Animator animator;
    public GameObject coin;
    Collider2D mycollider2D;

    public GameObject player;
    float m_x;
    bool isDie=false;

  

    void Start()
    {
        animator = GetComponent<Animator>();
        mycollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDie==false)
        {
            animator.enabled=true;
            m_x = transform.position.x;
            if (m_x <= left)
            {
            isRight = true;
            
            }
            if (m_x >= right)
            {
                isRight = false;
                
            }
            if (isRight)
            {
                transform.Translate(new Vector3(Time.deltaTime * 1, 0, 0));
                Vector3 scale = transform.localScale;
                scale.x *= (scale.x > 0) ? 1 : -1;
                transform.localScale = scale;
            }
            else
            {
                transform.Translate(new Vector3(Time.deltaTime * -1, 0, 0));
                Vector3 scale = transform.localScale;
                scale.x *= (scale.x > 0) ? -1 : 1;
                transform.localScale = scale;
            }


            if((player.transform.position.x<=right && player.transform.position.x>=left)&&(player.transform.position.y<=transform.position.y+0.5f&&player.transform.position.y>=transform.position.y-1f)){

                if(player.transform.position.x> transform.position.x ){
                    transform.Translate(new Vector3(Time.deltaTime * 2, 0, 0));
                    isRight=true;
                }else{
                    transform.Translate(new Vector3(Time.deltaTime * -2, 0, 0));
                    isRight=false;
                }
                
            }
        
        }else{
            animator.enabled=false;
        }
     }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("monters")){
            if (isRight==true)
            {
                isRight = false;
               
            
            }else{
                isRight = true;
                
            }
            
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet")){

            isDie=true;
            mycollider2D.isTrigger=true;

            soundGame.AmThanh.monterDie();
            //Destroy(gameObject);
            int randomNumber = Random.Range(3,9);
           
            for(int i=3;i<=randomNumber;i++){
                float randomX = Random.Range(0.1f,1f);
                float randomY = Random.Range(0.1f,1f);
                Vector3 playerPosition = transform.position;
                playerPosition.x+=randomX;
                playerPosition.y-=randomY;
                GameObject att = Instantiate(coin,playerPosition, Quaternion.identity);
                soundGame.AmThanh.dropCoin();
            }
            
        }


    }
        
}

    

