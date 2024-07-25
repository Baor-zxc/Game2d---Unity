using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player_Knight : MonoBehaviour
{
   float speed;
   public bool isRight = true;
   bool Jump;


   Animator animator;
   Rigidbody2D rigidb2D;
   public TMP_Text Diem;
   public TMP_Text SoDanT;
   public TMP_Text hp;
   public GameObject Win;
   public GameObject fire;

   public AudioClip soundJumping;
   public AudioClip soundAttackK;
   
   AudioSource audioSource;
   public int SoDan=10;
   public int upJump=350;
   public int scores;
   public int playerHp=100;

    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      animator = GetComponent<Animator>();
      rigidb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

      SoDanT.text=""+SoDan;
     
     int.TryParse(Diem.text, out scores);
     animator.SetBool("isWalking",false);
     animator.SetBool("isRunning",false);

      soundGame.AmThanh.playerWalk();
      soundGame.AmThanh.playerRun();

     // đi bộ
     if(Input.GetKey(KeyCode.D))
     {
        
        isRight = true;
        speed = 2f;
        transform.Translate(Time.deltaTime*speed,0,0);
        animator.SetBool("isWalking",true);
        Vector3 scale = transform.localScale;
        scale.x *= (scale.x > 0) ? 1 : -1;
        transform.localScale = scale;
        
     }
     if(Input.GetKey(KeyCode.A))
     {
        isRight = false;
        speed = 2f;
        transform.Translate(Time.deltaTime * -speed,0,0);
        animator.SetBool("isWalking",true);
        Vector3 scale = transform.localScale;
        scale.x *= (scale.x > 0) ? -1 : 1;
        transform.localScale = scale;
       
     }

    // chạy 
     if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
     {
        speed = 3f;
        transform.Translate(Time.deltaTime*speed,0,0);
        animator.SetBool("isRunning",true);
        animator.SetBool("isWalking",false);
        Vector3 scale = transform.localScale;
        scale.x *= (scale.x > 0) ? 1 : -1;
        transform.localScale = scale;
        isRight = true;
     }
     if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
     {
         speed = 3f;
         transform.Translate(Time.deltaTime * -speed,0,0);
         animator.SetBool("isRunning",true);
         animator.SetBool("isWalking",false);
         Vector3 scale = transform.localScale;
         scale.x *= (scale.x > 0) ? -1 : 1;
         transform.localScale = scale;
         isRight= false;
     }
      // nhayr
      if(Input.GetKeyDown(KeyCode.Space) && Jump == true)
      {
         animator.SetBool("isJumping",true);
         rigidb2D.AddForce(Vector2.up*upJump);
         audioSource.PlayOneShot(soundJumping);
         if(isRight)
         {
            Vector3 scale = transform.localScale;
            scale.x *= (scale.x > 0) ? 1 : -1;
            transform.localScale = scale;
         }else
         {
            Vector3 scale = transform.localScale;
            scale.x *= (scale.x > 0) ? -1 : 1;
            transform.localScale = scale;
         }
         Jump =false;
      }
      // tan cong 1

      if(Input.GetKeyDown(KeyCode.J))
      {
         animator.SetBool("isAttacking1",true);
      }
      if(Input.GetKeyUp(KeyCode.J))
      {
         animator.SetBool("isAttacking1",false);
      }
      // tan cong 2
      animator.SetBool("isAttacking2",false);
      if(Input.GetKeyDown(KeyCode.K))
      {
         animator.SetBool("isAttacking2",true);
         audioSource.PlayOneShot(soundAttackK);
      }
      // if(Input.GetKeyUp(KeyCode.K))
      // {
      //    animator.SetBool("isAttacking2",false);
      // }
      // tan cong 3
      if(Input.GetKeyDown(KeyCode.L))
      {
         animator.SetBool("isAttacking3",true);
      }
      if(Input.GetKeyUp(KeyCode.L))
      {
         animator.SetBool("isAttacking3",false);
      }
      // phong thu 

      if(Input.GetKeyDown(KeyCode.I))
      {
         animator.SetBool("isDefending",true);
      }
      if(Input.GetKeyUp(KeyCode.I))
      {
         animator.SetBool("isDefending",false);
      }

      if (Input.GetKeyDown(KeyCode.E)&&SoDan>0)
      {
         //audioSource.PlayOneShot(soundMagic);
         Vector3 playerPosition = transform.position;
         
         if(isRight){
            playerPosition.x+=1.4f;
         }else{
            playerPosition.x-=1.4f;
         }
         
         GameObject att = Instantiate(fire,playerPosition, Quaternion.identity);
         Destroy(att,1f);
         
         SoDan--;
      }
      // float time;
      // if (Input.GetKey(KeyCode.Q)&&SoDan>0)
      // {
      //    time =0f;
      //    time+=Time.deltaTime;
      //    if(time>=2f){
      //        Vector3 playerPosition = transform.position;
      //    if(isRight){
      //       playerPosition.x+=0.8f;
      //    }else{
      //       playerPosition.x-=0.8f;
      //    }

         
      //    GameObject att = Instantiate(fire,playerPosition, Quaternion.identity);

      //    att.transform.localScale*=2;
      //    //Destroy(att,1f);
      //    SoDan--;
      //    }


      // }
      if (Input.GetKeyUp(KeyCode.Q)&&SoDan>0)
      {
         Vector3 playerPosition = transform.position;
         if(isRight){
            playerPosition.x+=0.8f;
         }else{
            playerPosition.x-=0.8f;
         }

         
         GameObject att = Instantiate(fire,playerPosition, Quaternion.identity);

         att.transform.localScale*=2;
         Destroy(att,1f);
         SoDan--;
      }

      
      if(playerHp==0){
         Destroy(gameObject);
      }
      hp.text=""+playerHp;
     
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("land"))
      {
         Jump = true;
         animator.SetBool("isJumping",false);
      }
      // if(other.gameObject.CompareTag("Bullet")){
      //    SoDan+=1;
         
      // }

      if(other.gameObject.CompareTag("coin")){
         soundGame.AmThanh.passCoin();
         scores ++;
         Diem.text=""+scores;
      }
      if(other.gameObject.CompareTag("box")){
         
         scores ++;
         Diem.text=""+scores;
         soundGame.AmThanh.passCoin();

      }
      if(other.gameObject.CompareTag("trap")){
         playerHp-=5;
      }
      if(other.gameObject.CompareTag("monters")){
         playerHp-=5;
      }
     if(other.gameObject.CompareTag("win")){
         Win.SetActive(true);
         Time.timeScale=0;
      }
      
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      
      if(other.gameObject.CompareTag("LuongDan")){
         SoDan+=10;
         string name = other.attachedRigidbody.name;
         Destroy(GameObject.Find(name));
         soundGame.AmThanh.passCoin();

      }

      if(other.gameObject.CompareTag("heal")){
         soundGame.AmThanh.passCoin();
         playerHp+=10;
         string name = other.attachedRigidbody.name;
         Destroy(GameObject.Find(name));
      }
      if(other.gameObject.CompareTag("trap")){
         playerHp-=5;
      }

      if(other.gameObject.CompareTag("lava")){
         Destroy(gameObject);
      }
      
   }

   public static player_Knight ChuyenQua;

    void Awake()
    {
      ChuyenQua =this;
    }

    
}
