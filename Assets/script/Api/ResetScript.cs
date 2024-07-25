using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class reset : MonoBehaviour
{
    public TMP_InputField edtUser,edtPassword,otp;
    public TMP_Text txtMessage;

    public GameObject loading;


    void Update()
    {
      
    }


    public void LayLai(){
        StartCoroutine(Reset());
        Reset();
        loading.SetActive(true);
    }

    IEnumerator Reset()
    {
        // lay gia tri tu input field
        string user = edtUser.text;
        string pass = edtPassword.text;
        string sendotp = otp.text;
        txtMessage.text = "";

        if(user.Equals("")||pass.Equals("")||sendotp.Equals("")){
            txtMessage.text = "Nhập đầy đủ thông tin";
        }else
        {
            Resetmodel resetmodel = new Resetmodel(user,sendotp,pass);

            string jsonStringRequest = JsonConvert.SerializeObject(resetmodel);

            var request = new UnityWebRequest("http://localhost:3005/api/reset-pass", "POST");
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
                txtMessage.text = message.messenger;
                loading.SetActive(false);
            }
            request.Dispose();
        }
    }

    // IEnumerator Reset()
    // {
    //     // lay gia tri tu input field
    //     string user = edtUser.text;
    //     string pass = edtPassword.text;
    //     string sendotp = otp.text;
    //     txtMessage.text = "";

    //     if(user.Equals("")||pass.Equals("")||sendotp.Equals("")){
    //         txtMessage.text = "Nhập đầy đủ thông tin";
    //     }else
    //     {
    //         Resetmodel resetmodel = new Resetmodel(user,sendotp,pass);

    //         string jsonStringRequest = JsonConvert.SerializeObject(resetmodel);

    //         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/reset-password", "POST");
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
    //             txtMessage.text = message.notification;
    //             loading.SetActive(false);
    //         }
    //         request.Dispose();
    //     }
    // }
}
