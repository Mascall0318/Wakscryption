using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickText : MonoBehaviour
{
    public GameObject titleText;
    public float showinterval = 0.5f;  // ���� ���� ����
    public float midinterval = 0.1f;
    private Text textComponent;  // Text ������Ʈ

    private bool show = true;


    private void Start()
    {
        // Text ������Ʈ ���� ȹ��
        textComponent = GetComponent<Text>();

        // Coroutine ����
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        while (true)  // ���� �ݺ�
        {
            if (!show) 
            {
                // �����ϰ� �����
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0f);
            }
            else if(show)
            {
                // �ٽ� ���̰� �����
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1f);
            }

            // interval��ŭ ���
            yield return new WaitForSeconds(showinterval);

            // ����ȭ �߰� ����
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0.5f);

            // interval��ŭ ���
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
