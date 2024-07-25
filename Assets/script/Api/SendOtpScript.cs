using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SendOtpScript : MonoBehaviour
{
    public TMP_InputField edtUser;
    public TMP_Text txtMessage;
    public GameObject loading;
    

    void Update()
    {
       
           
    }

    public void GuiOtp(){
        StartCoroutine(guiotp());
        guiotp();
         loading.SetActive(true);
    }

    IEnumerator guiotp()
    {
        // lay gia tri tu input field
        string user = edtUser.text;
        txtMessage.text = "";

            UserOtpModel userOtp = new UserOtpModel(user);

            string jsonStringRequest = JsonConvert.SerializeObject(userOtp);

            var request = new UnityWebRequest("http://localhost:3005/api/send-otp", "POST");
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
    // IEnumerator guiotp()
    // {
    //     // lay gia tri tu input field
    //     string user = edtUser.text;
    //     txtMessage.text = "";

    //         UserOtpModel userOtp = new UserOtpModel(user);

    //         string jsonStringRequest = JsonConvert.SerializeObject(userOtp);

    //         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/send-otp", "POST");
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
                
    //         }
    //         request.Dispose();
    // }
}
