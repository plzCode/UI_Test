using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    public GameObject testprefab;

    public InputField _email_InputField;
    public InputField _password_InputField;
    public Button _loginButton;
    public Button _signUpButton;
    public Button _forgotButton;

    public Button _Test_Button;

    // Start is called before the first frame update
    void Start()
    {
        _loginButton.onClick.AddListener(LoginButtonClick);
        _signUpButton.onClick.AddListener(SignUpButtonClick);
        _forgotButton.onClick.AddListener(ForgotButtonClick);
        _Test_Button.onClick.AddListener(TestButtonClick);
    }

    public void TestButtonClick()
    {
        //PopupManager.Instance.ShowCommonPopup("ddd", "sss", null);
        //GameObject go = GameObject.Instantiate(testprefab);
        
        GameObject cy = GameObject.Find("Cylinder");

        if(cy != null)
        {
            GameObject cu = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Test/Cube"));

            cu.transform.SetParent(cy.transform);
            if (cy.transform.childCount >= 10)
            {
                GameObject.DestroyObject(cy);
            }
        }
        
    }

    public void ForgotButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.forgot);
        
    }

    public void SignUpButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.signup);
    }

    public void LoginButtonClick()
    {
        string email = _email_InputField.text;

        if (string.IsNullOrEmpty(email) == true)
        {
            Debug.Log("이메일을 입려해야 한다");
            return;
        }


        string password = _password_InputField.text;

        if (string.IsNullOrEmpty(password) == true)
        {
            Debug.Log("패스워드를 입력해야 한다");
            return;
        }


        NetworkManager.Instance.Login(email, password);

    }

}
