using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class CommonPopup : MonoBehaviour
{
    private static CommonPopup _Instance;
    public static CommonPopup Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(CommonPopup)) as CommonPopup;
            }
            return _Instance;
        }
    }

    public Text _Text_Title;
    public Text _Text_Body;

    public Button _Button_OK;
    public Button _Button_Cancel;

    UnityAction _Action_OK;
    UnityAction _Action_Cancel;

    // Use this for initialization
    void Awake()
    {
        UISetting();
    }

    void UISetting()
    {
        // ok.
        _Button_OK.onClick.AddListener(OKClicked);

        // cancel.
        _Button_Cancel.onClick.AddListener(CancelClicked);
    }

    public void SetInfo(string title, string body, UnityAction ok, UnityAction cancel)
    {
        // title.
        _Text_Title.text = title;

        // body.
        _Text_Body.text = body;

        // ok.
        _Action_OK = ok;

        // cancel.
        _Action_Cancel = cancel;
    }


    public void SetInfoText(string title, string body, UnityAction ok, UnityAction cancel)
    {

        /*

        UILocalization titleLoc = _Text_Title.GetComponent<UILocalization>();
        UILocalization bocyLoc = _Text_Body.GetComponent<UILocalization>();

        bocyLoc.enabled = false;

        titleLoc.enabled = false;

        */
        // title.
        _Text_Title.text = title;

        // body.
        _Text_Body.text = body;

        // ok.
        _Action_OK = ok;

        // cancel.
        _Action_Cancel = cancel;


   
    }



    public void SetInfo(string title, string body, UnityAction ok)
    {
        /*

        UILocalization titleLoc = _Text_Title.GetComponent<UILocalization>();
        UILocalization bocyLoc = _Text_Body.GetComponent<UILocalization>();


        bocyLoc.enabled = true;

        titleLoc.enabled = true;

        // title.

        // title.
        titleLoc.Key = title;

        // body.
        bocyLoc.Key = body;

        */
        // ok.
        _Action_OK = ok;
        _Button_OK.transform.localPosition = new Vector3(0, _Button_OK.transform.localPosition.y, _Button_OK.transform.localPosition.z);

        // cancel.
        _Action_Cancel = null;
        _Button_Cancel.gameObject.SetActive(false);
    }

    public void SetInfoText(string title, string body, UnityAction ok)
    {

        /*
        UILocalization titleLoc = _Text_Title.GetComponent<UILocalization>();
        UILocalization bocyLoc = _Text_Body.GetComponent<UILocalization>();

        bocyLoc.enabled = false;

        titleLoc.enabled = false;
        */

        // title.
        _Text_Title.text = title;

        // body.
        _Text_Body.text = body;

        // ok.
        _Action_OK = ok;
        _Button_OK.transform.localPosition = new Vector3(0, _Button_OK.transform.localPosition.y, _Button_OK.transform.localPosition.z);

        // cancel.
        _Action_Cancel = null;
        _Button_Cancel.gameObject.SetActive(false);
    }




    void OKClicked()
    {
     

        if (_Action_OK != null)
            _Action_OK();

        PopupManager.Instance.Dismiss();
    }

    void CancelClicked()
    {
      

        if (_Action_Cancel != null)
            _Action_Cancel();

        PopupManager.Instance.Dismiss();
    }

    public void Vibrate()
    {
       // Vibration.Vibrate();
    }
}
