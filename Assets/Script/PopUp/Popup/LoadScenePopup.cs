using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScenePopup : MonoBehaviour
{
    public Slider _Slider;

    public void LoadScene(string scene)
    {
         StartCoroutine(Load(scene));
    }

    IEnumerator Load(string scene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

      

        while(async.isDone == false)
        {
            _Slider.value = async.progress;
            //Debug.Log("Load : " + async.progress);
            yield return null;
        }

    }
}
