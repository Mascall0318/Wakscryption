using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTitle : MonoBehaviour
{
    static bool clickedTitle = false;

    public GameObject titleObject;
    public Image titleImage; // titleObject의 Image를 titleImage로 가져오기
    public float fadeDuration = 2.0f;
    public float fadeTime = 0.1f;

    public ClickText clickText;

    public void Awake()
    {
        if (!clickedTitle)
        {
            titleObject.SetActive(true);
            titleImage.enabled = true;
        }
        else { titleObject.SetActive(false);}
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickedTitle)
        {
            clickText.StopFadeText();
            StartCoroutine(FadeTitle());
        }
    }

    private IEnumerator FadeTitle()
    {
        float elapsed = 0f;
        float fadeBlack = 1f;

        while (elapsed< fadeDuration)
        {
            titleImage.color = new Color(titleImage.color.r, titleImage.color.g, titleImage.color.b, fadeBlack);
            elapsed += Time.deltaTime;
            if (fadeBlack > 0f)
            {
                fadeBlack -= 0.1f;
                yield return new WaitForSeconds(fadeTime);
            }
            yield return null;
        }

        clickedTitle = true;

        titleImage.enabled = false;
        titleObject.SetActive(false);
    }
}
