using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

using UnityEngine.Networking;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;

/*

{
    "errorMsg":""
}
*/

public partial class NetworkManager : MonoBehaviour
{
   
    string baseUri_SignUp = "https://uy2emr5v3e.execute-api.ap-northeast-2.amazonaws.com/metabeta01/user";
    string baseUri_SignUp_Confirm = "https://uy2emr5v3e.execute-api.ap-northeast-2.amazonaws.com/metabeta01/user/";
    string baseUri_Login = "https://uy2emr5v3e.execute-api.ap-northeast-2.amazonaws.com/metabeta01/user/";


    public AWS_Return_Login_data login_userdata = new AWS_Return_Login_data();

    public static string UserEmail; // Tmp User ID

    private static NetworkManager instance = null;


    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static NetworkManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
        
            Destroy(this.gameObject);
        }
    }
      
  
    public void SignUp(string email , string password, int age , string username)
    {
        //  Aws_SignUp signup = new Aws_SignUp(email, password);
        Aws_SignUp signup = new Aws_SignUp(email, password, username,  age);

        string json = JsonUtility.ToJson(signup);           

        StartCoroutine(WebRequest("POST",baseUri_SignUp, json , SignUp_Return));

    }

    public void SignUp_Return(string rp)
    {
        AWS_Return_SignUp returnVal = JsonUtility.FromJson<AWS_Return_SignUp>(rp);
        Debug.Log(returnVal.errorMsg);

        if (returnVal.errorMsg == "")
        {
            UserEmail = returnVal.email;
            UIMainMenu.Instance.SetUI(E_UIMainMenu.signupcon);
        }

    }

    public void SignUpConfirm(string email, string code)
    {
        //  Aws_SignUp signup = new Aws_SignUp(email, password);
        Aws_SignUp_Confirm signup_confirm = new Aws_SignUp_Confirm();

        signup_confirm.email = email;
        signup_confirm.code = code;

        string json = JsonUtility.ToJson(signup_confirm);

        StartCoroutine(WebRequest("PUT", baseUri_SignUp_Confirm + email, json, SignUp_Confirm_Return));

    }

    public void SignUp_Confirm_Return(string rp)
    {
        
        AWS_Return_SignUp returnVal = JsonUtility.FromJson<AWS_Return_SignUp>(rp);
        Debug.Log(returnVal.errorMsg);

        if (returnVal.errorMsg == "")
        {
            UIMainMenu.Instance.SetUI(E_UIMainMenu.login);
        }
        

    }

    


    public void Login(string email, string password)
    {
        Aws_Login login = new Aws_Login();
        login.email = email;
        login.password = password;
        
        string json = JsonUtility.ToJson(login);

        StartCoroutine(WebRequest("POST",baseUri_Login  + email, json, Login_Return));

    }

    

    public void Login_Return(string rp)
    {
        Debug.Log(rp);

        AWS_Return_Login returnVal = JsonUtility.FromJson<AWS_Return_Login>(rp);

        login_userdata = returnVal.data;
        //    AWS_Return_SignUp returnVal = JsonUtility.FromJson<AWS_Return_SignUp>(rp);
        //  Debug.Log(returnVal.errorMsg);

    }


    IEnumerator WebRequest(string wtd , string url, string json, UnityAction<string> rp_Method)
    {
        var uwr = new UnityWebRequest(url,  wtd ); //GET,POST

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);


        if (wtd != "GET")
        {
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        }
     
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        uwr.SetRequestHeader("Content-Type", "application/json");
                      
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError ||
            uwr.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
         
            if (rp_Method != null)
            {
                rp_Method(uwr.downloadHandler.text);
            }
      
        }

        uwr.Dispose();
    }


}
