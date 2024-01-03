using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickText : MonoBehaviour
{
    public GameObject titleText;
    public float showinterval = 0.5f;  // 투명도 변경 간격
    public float midinterval = 0.1f;
    private Text textComponent;  // Text 컴포넌트

    private bool show = true;


    private void Start()
    {
        // Text 컴포넌트 참조 획득
        textComponent = GetComponent<Text>();

        // Coroutine 시작
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        while (true)  // 무한 반복
        {
            if (!show) 
            {
                // 투명하게 만들기
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0f);
            }
            else if(show)
            {
                // 다시 보이게 만들기
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1f);
            }

            // interval만큼 대기
            yield return new WaitForSeconds(showinterval);

            // 투명화 중간 구간
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0.5f);

            // interval만큼 대기
            yield return new WaitForSeconds(midinterval);

            show = !show;
        }
    }

    public void StopFadeText()
    {
        if (textComponent != null)
        {
            StopCoroutine(FadeText());
            textComponent=null;
        }

        titleText.SetActive(false);
    }
}
