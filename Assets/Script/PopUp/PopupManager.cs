using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Popup_UI
{
    Common,
    Update,
    LoadScene,
    Loading,
    Quit,
   

    MAX
}




public class PopupManager : MonoBehaviour
{
    private static PopupManager _Instance;
    public static PopupManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = Instantiate(Resources.Load<PopupManager>("PopupManager"));

                _Instance.transform.localScale = Vector3.one;
            }
            return _Instance;
        }
    }

    public GameObject[] Popup_Obj;
    [HideInInspector] public GameObject Route_Obj;			// 생성 경로.
    [HideInInspector] public GameObject Load_Obj;			// 로드 오브젝트.

    public static Popup_UI Popup_UI;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        GameObject uiRoot = GameObject.Find("UIRoot");
        

        transform.SetParent(uiRoot.transform);

        Popup_Obj = new GameObject[(int)Popup_UI.MAX];
        Route_Obj = this.gameObject;
    }

    public void Dismiss()
    {
        Dismiss((int)Popup_UI);
    }

    public void ShowCommonPopup(string title, string body, UnityAction ok, UnityAction cancel)
    {
        Popup_UI = Popup_UI.Common;
        Show();

        CommonPopup.Instance.SetInfo(title, body, ok, cancel);
    }

    public void ShowCommonPopupText(string title, string body, UnityAction ok, UnityAction cancel)
    {
        Popup_UI = Popup_UI.Common;
        Show();

        CommonPopup.Instance.SetInfoText(title, body, ok, cancel);
    }






    public void ShowCommonPopup(string title, string body, UnityAction ok)
    {
        Popup_UI = Popup_UI.Common;
        Show();

        CommonPopup.Instance.SetInfo(title, body, ok);
    }

    public void ShowCommonPopupText(string title, string body, UnityAction ok)
    {
        Popup_UI = Popup_UI.Common;
        Show();

        CommonPopup.Instance.SetInfoText(title, body, ok);
    }




    public void ShowUpdatePopup()
    {
        Popup_UI = Popup_UI.Update;
        Show();
    }

    public void ShowLoadScene(string scene)
    {
        Popup_UI = Popup_UI.LoadScene;
        Show();

        LoadScenePopup loadscene = GetPopupObj().GetComponent<LoadScenePopup>();
        loadscene.LoadScene(scene);
    }

    public void ShowLoading()
    {
        Popup_UI = Popup_UI.Loading;
        Show();
    }

    public void ShowQuitPopup()
    {
        Popup_UI = Popup_UI.Quit;
        Show();
    }

    void Show()
    {
        switch (Popup_UI)
        {
            case Popup_UI.Common:
                PopupCreation((int)Popup_UI, "CommonPopup");
                break;
            case Popup_UI.Update:
                PopupCreation((int)Popup_UI, "UpdatePopup");
                break;
            case Popup_UI.LoadScene:
                PopupCreation((int)Popup_UI, "LoadScenePopup");
                break;
            case Popup_UI.Loading:
                PopupCreation((int)Popup_UI, "LoadingPopup");
                break;
            case Popup_UI.Quit:
                PopupCreation((int)Popup_UI, "QuitPopup");
                break;
        }
    }

    void PopupCreation(int index, string name)
    {
        Debug.Log(name);


        for (int i = 0; i < (int)Popup_UI.MAX; ++i)
        {
            if (i != index)
            {
                if (Popup_Obj[i] != null)
                    Dismiss(i);
            }
        }

        if (Popup_Obj[index] == null)
        {
            Load_Obj = Resources.Load("Popup/" + name) as GameObject;
            if (Load_Obj != null)
            {
                Popup_Obj[index] = Amisc.AddChild(Route_Obj, Load_Obj);

                Popup_Obj[index].name = name;

                Popup_Obj[index].transform.localScale = Vector3.one;
            }
        }
        else
        {
            Popup_Obj[index].SetActive(true);
        }
    }

    GameObject GetPopupObj()
    {
        return Popup_Obj[(int)Popup_UI];
    }

    void Dismiss(int index)
    {
        if (Popup_Obj[index] != null)
            Destroy(Popup_Obj[index].gameObject);
    }
}
