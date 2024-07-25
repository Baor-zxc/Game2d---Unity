using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SavePosition : MonoBehaviour
{
     
    public GameObject player;
    String positionX;
    String positionY;
    String positionZ;
    int Score;

    String user;

    void Update()
    {
        
        Score=player_Knight.ChuyenQua.scores;
    }


    public void Luu(){
        Debug.Log("chay luu");
        StartCoroutine(saveposition());
        saveposition();
    }

    public void LuuDiem(){
        Debug.Log("chay luu");
        StartCoroutine(saveScore());
        saveScore();
    }

    IEnumerator saveposition()
    {
        user = LoginScript.ChuyenQua.user;
        Debug.Log(user);
        positionX = player.transform.position.x+"";
        positionY = player.transform.position.y+"";
        positionZ = player.transform.position.z+"";


        SavePostionModel save = new SavePostionModel(user,positionX,positionY,positionZ);
        string jsonStringRequest = JsonConvert.SerializeObject(save);

        var request = new UnityWebRequest("http://localhost:3005/api/save-position", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
            Debug.Log(message.messenger);
            
        }
        request.Dispose();
    }
    
    IEnumerator saveScore()
    {
        user = LoginScript.ChuyenQua.user;
        Debug.Log(user);
        
        ScoreModel save = new ScoreModel(user,Score);
        string jsonStringRequest = JsonConvert.SerializeObject(save);

        var request = new UnityWebRequest("http://localhost:3005/api/save-score", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
            Debug.Log(message.messenger);
            
        }
        request.Dispose();
    }

// IEnumerator saveposition()
//     {
//         user = LoginScript.ChuyenQua.user;
//         Debug.Log(user);
//         positionX = player.transform.position.x+"";
//         positionY = player.transform.position.y+"";
//         positionZ = player.transform.position.z+"";


//         SavePostionModel save = new SavePostionModel(user,positionX,positionY,positionZ);
//         string jsonStringRequest = JsonConvert.SerializeObject(save);

//         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/save-position", "POST");
//         byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
//         request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//         request.downloadHandler = new DownloadHandlerBuffer();
//         request.SetRequestHeader("Content-Type", "application/json");
//         yield return request.SendWebRequest();

//         if (request.result != UnityWebRequest.Result.Success)
//         {
//             Debug.Log(request.error);
//         }
//         else
//         {
//             var jsonString = request.downloadHandler.text.ToString();
//             MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
//             Debug.Log(message.notification);
            
//         }
//         request.Dispose();
//     }
    
//     IEnumerator saveScore()
//     {
//         user = LoginScript.ChuyenQua.user;
//         Debug.Log(user);
        
//         ScoreModel save = new ScoreModel(user,Score);
//         string jsonStringRequest = JsonConvert.SerializeObject(save);

//         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/save-score", "POST");
//         byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
//         request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//         request.downloadHandler = new DownloadHandlerBuffer();
//         request.SetRequestHeader("Content-Type", "application/json");
//         yield return request.SendWebRequest();

//         if (request.result != UnityWebRequest.Result.Success)
//         {
//             Debug.Log(request.error);
//         }
//         else
//         {
//             var jsonString = request.downloadHandler.text.ToString();
//             MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
//             Debug.Log(message.notification);
            
//         }
//         request.Dispose();
//     }


}
