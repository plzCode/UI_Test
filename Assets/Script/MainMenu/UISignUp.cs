using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignUp : MonoBehaviour
{

    public InputField _email_InputField;
    public InputField _password_InputField;
    public InputField _passwordConfirm_InputField;
    public InputField _username_InputField;
    public InputField _age_InputField;

    public Button _confirmButton;

    public Button _cancleButton;


    public void Start()
    {

        _confirmButton.onClick.AddListener(ConfirmButtonClick);
        _cancleButton.onClick.AddListener(CancleButtonClick);

    }

    public void CancleButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.login);
    }


    public void ConfirmButtonClick()
    {
        string email = _email_InputField.text;

        if (string.IsNullOrEmpty(email) == true)
        {

            Debug.Log("이메일을 입력해야 한다");
            return;
        }


        string password = _password_InputField.text;

        string passwordConfirm = _passwordConfirm_InputField.text;

        if(password  != passwordConfirm)
        {
            Debug.Log("패스워드 지대로 확인해라");
            return;
        }
                
        string username = _username_InputField.text;

        int age = int.Parse(_age_InputField.text);





        NetworkManager.Instance.SignUp(email, password, age, username);


    }






}
