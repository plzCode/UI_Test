using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuitPopup : MonoBehaviour
{
    private static QuitPopup _Instance;
    public static QuitPopup Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(QuitPopup)) as QuitPopup;
            }
            return _Instance;
        }
    }

    public Button _Button_OK;
    public Button _Button_Cancel;
    public Button _Button_X;


    // Use this for initialization
    void Start()
    {
        UISetting();
    }

    void UISetting()
    {
        // ok.
        _Button_OK.onClick.AddListener(OKClicked);

        // cancel.
        _Button_Cancel.onClick.AddListener(CancelClicked);

        _Button_X.onClick.AddListener(CancelClicked);
    }

    void OKClicked()
    {

        Application.Quit();

        PopupManager.Instance.Dismiss();
    }

    void CancelClicked()
    {

        PopupManager.Instance.Dismiss();
    }

    public void Vibrate()
    {
       // Vibration.Vibrate();
    }
}
