using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIForgot : MonoBehaviour
{
    public Button _cancleButton;
    public Button _sendEmailButton;
    public InputField _email_InputField;

    private void Awake()
    {
        _cancleButton.onClick.AddListener(CancleButtonClick);
        _sendEmailButton.onClick.AddListener(SendEmailButtonClick);
    }
    
    void CancleButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.login);
    }
    void SendEmailButtonClick()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
