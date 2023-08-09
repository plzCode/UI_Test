using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIForgotConfirm : MonoBehaviour
{
    public InputField _code_InputField;
    public InputField _password_InputField;
    public InputField _password_con_InputField;

    public Button _confirm_Button;
    public Button _cancle_Button;

    private void Awake()
    {
        _confirm_Button.onClick.AddListener(ConfirmButtonClick);
        _cancle_Button.onClick.AddListener(CancleButtonClick);
    }

    public void CancleButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.login);
    }

    public void ConfirmButtonClick()
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
