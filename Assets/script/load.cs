using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{

    public GameObject win;
    public GameObject lost;
    public GameObject player;

    void Update()
    {
        if(player == null){
            lost.SetActive(true);
        }
    }
    // Start is called before the first frame update
    public void man_2(){
        Time.timeScale=1;
        SceneManager.LoadScene("Secene_2");
    }
    public void game_1(){
        Time.timeScale=1;
        SceneManager.LoadScene("Secene_tileMap");

    }
    public void game_2(){
        Time.timeScale=1;
        SceneManager.LoadScene("Secene_normal");

    }

    public void Pause(){
        Time.timeScale=0;
    }
    public void Continue(){
        Time.timeScale=1;
    }


}
