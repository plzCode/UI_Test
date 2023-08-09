using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignUpConfirm : MonoBehaviour
{
    public InputField _code_InputField;
    public Button _confirm_Button;
    public Button _cancle_Button;

    private void Awake()
    {
        _confirm_Button.onClick.AddListener(ConfirmButtonClick);
        _cancle_Button.onClick.AddListener(CancleButtonClick);
    }
    public void ConfirmButtonClick()
    {
        string code = _code_InputField.text;

        if (string.IsNullOrEmpty(code) == true)
        {
            Debug.Log("이메일을 입력해야 한다");
            return;
        }
        
        NetworkManager.Instance.SignUpConfirm(NetworkManager.UserEmail, code);
    }
    public void CancleButtonClick()
    {
        UIMainMenu.Instance.SetUI(E_UIMainMenu.login);
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
