using System;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPosition : MonoBehaviour
{
    int Score;
    String positionXString;
    String positionYString;
    String positionZString;
    float positionX, positionY, positionZ;
    public TMP_Text Diem;
    
    public GameObject player;
    String user;
    void Start()
    {
        layDiem();
    }
    void Update()
    {
        
    }
  
    public void getposition(){
        StartCoroutine(GetPosition());
        GetPosition();
    }
    IEnumerator GetPosition()
    {
        user = LoginScript.ChuyenQua.user;

        string url = "http://localhost:3005/api//get-user/"+user;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string jsonString = request.downloadHandler.text;
            userDetails UserDetails = JsonUtility.FromJson<userDetails>(request.downloadHandler.text);

            // lay vi tri
            positionXString = UserDetails.positionX;
            positionYString = UserDetails.positionY;
            positionZString = UserDetails.positionZ;
            Score = UserDetails.score;
            // chuyen sang float 
            float.TryParse(positionXString, out positionX);
            float.TryParse(positionYString, out positionY);
            float.TryParse(positionZString, out positionZ);
            Diem.text="Diem : "+Score;
            // set vi tri 
            Vector3 startingPosition = new Vector3(positionX, positionY,positionZ);
            player.transform.position=startingPosition;
            
        }

        request.Dispose();
    }

    public void layDiem(){
        StartCoroutine(GetScore());
        GetScore();
    }
    IEnumerator GetScore()
    {
        user = LoginScript.ChuyenQua.user;

        string url = "http://localhost:3005/api//get-user/"+user;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string jsonString = request.downloadHandler.text;
            userDetails UserDetails = JsonUtility.FromJson<userDetails>(request.downloadHandler.text);

            Score = UserDetails.score;
            Diem.text=""+Score;
            
        }

        request.Dispose();
    }



    // IEnumerator GetPosition()
    // {
    //     user = LoginScript.ChuyenQua.user;

    //     string url = "https://hoccungminh.dinhnt.com/fpt/details?id="+user;
    //     UnityWebRequest request = UnityWebRequest.Get(url);
    //     yield return request.SendWebRequest();

    //     if (request.result != UnityWebRequest.Result.Success)
    //     {
    //         Debug.LogError(request.error);
    //     }
    //     else
    //     {
    //         string jsonString = request.downloadHandler.text;
    //         userDetails UserDetails = JsonUtility.FromJson<userDetails>(request.downloadHandler.text);

    //         // lay vi tri
    //         positionXString = UserDetails.positionX;
    //         positionYString = UserDetails.positionY;
    //         positionZString = UserDetails.positionZ;
    //         Score = UserDetails.score;
    //         // chuyen sang float 
    //         float.TryParse(positionXString, out positionX);
    //         float.TryParse(positionYString, out positionY);
    //         float.TryParse(positionZString, out positionZ);
    //         Diem.text="Diem : "+Score;
    //         // set vi tri 
    //         Vector3 startingPosition = new Vector3(positionX, positionY,positionZ);
    //         player.transform.position=startingPosition;
            
    //     }

    //     request.Dispose();
    // }

    // public void layDiem(){
    //     StartCoroutine(GetScore());
    //     GetScore();
    // }
    // IEnumerator GetScore()
    // {
    //     user = LoginScript.ChuyenQua.user;

    //     string url = "https://hoccungminh.dinhnt.com/fpt/details?id="+user;
    //     UnityWebRequest request = UnityWebRequest.Get(url);
    //     yield return request.SendWebRequest();

    //     if (request.result != UnityWebRequest.Result.Success)
    //     {
    //         Debug.LogError(request.error);
    //     }
    //     else
    //     {
    //         string jsonString = request.downloadHandler.text;
    //         userDetails UserDetails = JsonUtility.FromJson<userDetails>(request.downloadHandler.text);

    //         Score = UserDetails.score;
    //         Diem.text=""+Score;
            
    //     }

    //     request.Dispose();
    // }
}
