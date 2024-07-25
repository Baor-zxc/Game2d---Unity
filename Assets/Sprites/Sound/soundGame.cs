using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundGame : MonoBehaviour
{
    public AudioClip soundMontersDie,soundPlayerWalk,soundPassCoin,soundDropCoin;
    AudioSource audioSource;
    void Start()
    {
        audioSource =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void monterDie(){
        audioSource.PlayOneShot(soundMontersDie);
    }

    public void playerWalk()
    {
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A))
        {
            if (audioSource != null && soundPlayerWalk != null)
            {
                audioSource.clip = soundPlayerWalk;
                audioSource.Play();
            }else{
                
            }
        }else if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A))
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }

        // chay 
       
    }

    public void playerRun(){
        if ((Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A))&&Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (audioSource != null && soundPlayerWalk != null)
            {
                audioSource.clip = soundPlayerWalk;
                audioSource.pitch = 3f;
                audioSource.Play();
            }else{
                
            }
        }else if((Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A))&&Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }

    public void passCoin(){
        audioSource.PlayOneShot(soundPassCoin);
    }
    public void dropCoin(){
        audioSource.PlayOneShot(soundDropCoin);
    }

    public static soundGame AmThanh;

    void Awake()
    {
      AmThanh =this;
    }
}
