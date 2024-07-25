using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class LoginScript : MonoBehaviour
{

    public TMP_InputField edtUser,edtPassword;
    public TMP_Text txtMessage;

    public Button btPlay;
    public GameObject panel;
    public GameObject loading;
    bool a= false;

    public String user;



    string kiemTra = "Đăng nhập thành công";
    bool kiemTraDN;

    public void Update()
    {
        if(kiemTraDN == true){
            btPlay.gameObject.SetActive(true);
            panel.SetActive(false);
        }
        
        
    }
    public void DangNhap(){
        loading.SetActive(true);
        StartCoroutine(Login());
        Login();
        a = true;
    }

    IEnumerator Login()
    {
        // lay gia tri tu input field

        user = edtUser.text;
        string pass = edtPassword.text;
        txtMessage.text = "1";

        UserRegisterModel userLogin = new UserRegisterModel(user,pass);

            string jsonStringRequest = JsonConvert.SerializeObject(userLogin);

            var request = new UnityWebRequest("http://localhost:3005/api/login", "POST");
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
                if(message.status==111){
                    kiemTraDN = true;
                    
                }
                
            }
            request.Dispose();
    }

    // IEnumerator Login()
    // {
    //     // lay gia tri tu input field

    //     user = edtUser.text;
    //     string pass = edtPassword.text;
    //     txtMessage.text = "";

    //     UserRegisterModel userLogin = new UserRegisterModel(user,pass);

    //         string jsonStringRequest = JsonConvert.SerializeObject(userLogin);

    //         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/login", "POST");
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

    //             if(txtMessage.text.Equals(kiemTra)){
    //                 kiemTraDN = true;
    //             }
                
    //         }
    //         request.Dispose();
    // }


    public static LoginScript ChuyenQua;

    void Awake()
    {
        ChuyenQua =this;
    }
}
