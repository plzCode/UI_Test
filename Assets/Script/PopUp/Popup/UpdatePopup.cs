using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePopup : MonoBehaviour
{
    public Button _Button_Update;
    public Button _Button_Cancel;

    // Use this for initialization
    void Awake()
    {
        UISetting();
    }

    void UISetting()
    {
        _Button_Update.onClick.AddListener(UpdateClicked);
        _Button_Cancel.onClick.AddListener(CancelClicked);
    }

    void UpdateClicked()
    {

       // Application.OpenURL("http://106.250.183.138:8032/svr/link-install.php");
    }

    void CancelClicked()
    {

        Application.Quit();
    }

    public void Vibrate()
    {
    //    Vibration.Vibrate();
    }
}
