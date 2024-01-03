using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fallingtitle : MonoBehaviour
{
    public GameObject buttoncanvas;
    public GameObject plashcan;
    public GameObject background;
    public Image plash;
    public GameObject one;
    public GameObject one2;
    public GameObject one3;
    public GameObject two;
    public GameObject two2;
    public GameObject thr;
    public GameObject thr2;
    public GameObject four;
    public GameObject four2;
    public GameObject five;
    public GameObject five2;
    public GameObject fall;
    public GameObject show;
    [SerializeField]
    float fadeTime;
    int click = 0;
    //int i = 0;
    //float j = 1.0f;
    //Color color;

    public void Click()
    {
        switch (click)
        {
            case 0:
                one.SetActive(true);
                one2.SetActive(true);
                one3.SetActive(true);
                break;
            case 1:
                two.SetActive(true);
                two2.SetActive(true);
                break;
            case 2:
                thr.SetActive(true);
                thr2.SetActive(true);
                break;
            case 3:
                four.SetActive(true);
                four2.SetActive(true);
                break;
            case 4:
                five.SetActive(true);
                five2.SetActive(true);
                break;
            case 5:
                fall.SetActive(true);
                break;
        }
        click++;
    }

    private void Start()
    {
        Invoke("Click", 1f);
        Invoke("Click", 1.45f);
        Invoke("Click", 1.6f);
        Invoke("Click", 1.75f);
        Invoke("Click", 1.9f);
        Invoke("Click", 1.92f);
    }


    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = plash.color;
            color.a = Mathf.Lerp(start, end, percent);
            plash.color = color;

            yield return null;
        }
        buttoncanvas.SetActive(true);
    }
    //public void flash()
    //{
    //    color = plash.color;
    //    StartCoroutine("flaash");
    //}


    //IEnumerator flaash()
    //{
    //    while (true)
    //    {
    //        j -= 0.01f;
    //        i++;
    //        color.a = j;
    //        plash.color = color;
    //        if (i > 99)
    //        {
    //            buttoncanvas.SetActive(true);
    //        }
    //        yield return new WaitForSeconds(0.005f);
    //        j -= 0.01f;
    //        i++;
    //        color.a = j;
    //        plash.color = color;
    //        if (i > 99)
    //        {
    //            buttoncanvas.SetActive(true);
    //        }
    //        yield return new WaitForSeconds(0.005f);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        one.SetActive(false) ;
        one2.SetActive(false);
        one3.SetActive(false);
        two.SetActive(false);
        two2.SetActive(false);
        thr.SetActive(false);
        thr2.SetActive(false);
        four.SetActive(false);
        four2.SetActive(false);
        five.SetActive(false);
        five2.SetActive(false);
        fall.SetActive(false);
        show.SetActive(true);
        plashcan.SetActive(true);
        background.SetActive(true);
        StartCoroutine(Fade(1,0));
    }
}
