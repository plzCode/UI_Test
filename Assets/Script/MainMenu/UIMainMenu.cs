using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum E_UIMainMenu
{
    login,
    signup,
    forgot,
    signupcon,
    forgotcon,


    Count
}


public class UIMainMenu : MonoBehaviour
{
    public List<GameObject> pannels = new List<GameObject>();
    //                  key : value
    public Dictionary<string, GameObject> panelDic = new Dictionary<string, GameObject>();

    private static UIMainMenu instance = null;
    
    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static UIMainMenu Instance
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

    private void Awake()
    {
        instance = this;

        for(int i = 0; i<transform.childCount; i++)
        {
            panelDic.Add(transform.GetChild(i).gameObject.name, transform.GetChild(i).gameObject);
        }
        
        
        /*
        GameObject signUpPanel = gameObject.transform.Find("SignUpPanel").gameObject;
        GameObject loginPanel = transform.Find("LoginPanel").gameObject;

        panelDic.Add("SignUpPanel",signUpPanel);
        panelDic.Add("LoginPanel",loginPanel);
        */
        SetUI(E_UIMainMenu.login);
    }

    public void SetUI(E_UIMainMenu emenu) 
    {
        
        foreach (KeyValuePair<string,GameObject> item in panelDic)
        {
            if(item.Key == emenu.ToString())
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
        /*
        for (int i = 0; i<pannels.Count; i++)
        {
            if(pannels[i].name == uiName)
            {
                pannels[i].SetActive(true);
            }
            else
            {
                pannels[i].SetActive(false);
            }
        }
        */
        //panels.Find(x => x.name == uiName).SetActive(true);


    
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
