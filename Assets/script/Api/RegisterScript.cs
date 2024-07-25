using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RegisterScript : MonoBehaviour
{
    public TMP_InputField edtUser,edtPassword,edtRepassword;
    public TMP_Text txtMessage;

    public GameObject loading;

    void Start()
    {
       
    }

    void Update()
    {
        
    }


    public void DangKy(){
        loading.SetActive(true);
        StartCoroutine(Register());
        Register();
    }
    IEnumerator Register()
    {
            // lay gia tri tu input field

        string user = edtUser.text;
        string pass = edtPassword.text;
        string rePass = edtRepassword.text;
        txtMessage.text = "";

        if(rePass.Equals(pass))
        {

            UserRegisterModel userRegister = new UserRegisterModel(user,pass);

            string jsonStringRequest = JsonConvert.SerializeObject(userRegister);

            var request = new UnityWebRequest("http://localhost:3005/api/register", "POST");
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
        }else{
            txtMessage.text = "hai mật khẩu không trùng nhau vui lòng nhập lại !";
            loading.SetActive(false);
        }
    }
    // IEnumerator Register()
    // {
    //         // lay gia tri tu input field

    //     string user = edtUser.text;
    //     string pass = edtPassword.text;
    //     string rePass = edtRepassword.text;
    //     txtMessage.text = "";

    //     if(rePass.Equals(pass))
    //     {

    //         UserRegisterModel userRegister = new UserRegisterModel(user,pass);

    //         string jsonStringRequest = JsonConvert.SerializeObject(userRegister);

    //         var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/register", "POST");
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
    //     }else{
    //         txtMessage.text = "hai mật khẩu không trùng nhau vui lòng nhập lại !";
    //         loading.SetActive(false);
    //     }
    // }
}
