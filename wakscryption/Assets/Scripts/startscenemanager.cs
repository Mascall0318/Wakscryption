using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startscenemanager: MonoBehaviour
{
    public GameObject buttoncanvas;
    public Image titlehamyun;
    public GameObject titlehamyuncanvas;
    [SerializeField]
    float fadeTime;

    public void Click()
    {
        buttoncanvas.SetActive(false);
        StartCoroutine(Fade(0, 1));
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime; // fadeTime을 어떤 컴퓨터에서 실행하더라도 일정한 값이 나올 수 있게 만든게 percent

            Color color = titlehamyun.color;
            color.a = Mathf.Lerp(start, end, percent);
            titlehamyun.color = color;

            yield return null;
        }
        LoadingScene("TitleScene");
    }
    //public bool first = true;
    //int i = 0;
    //float j = 0.0f;
    //Color color;
    //public void click()
    //{
    //    buttoncanvas.SetActive(false);
    //    titlehamyuncanvas.SetActive(true);
    //    color = titlehamyun.color;
    //    StartCoroutine("gamego");
    //}

    //IEnumerator gamego()
    //{
    //    while (true)
    //    {
    //        j += 0.2f;
    //        i++;
    //        color.a = j;
    //        titlehamyun.color = color;
    //        if (i > 4)
    //        {
    //            LoadingScene("TitleScene");
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}




    public void LoadingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
