using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;

public class Typer : MonoBehaviour
{
    string textContent;
    Text printedText;
    public float typingSpeed = 0.1f;
    public float skipSpeed = 0.01f;
    private bool skipTyping = false;

    void Awake()
    {
        printedText = GetComponent<Text>();
    }

    void OnEnable()
    {
        textContent = printedText.text;
        printedText.text = "";

        StartCoroutine(TypingRoutine());
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            skipTyping = true;
            typingSpeed = skipSpeed;
        }
    }


    IEnumerator TypingRoutine()
    {
        int typingLength = textContent.GetTypingLength();

        for (int index = 0; index <= typingLength; index++)
        {
            printedText.text = textContent.Typing(index);
            if (skipTyping)
            {
                yield return new WaitForSeconds(skipSpeed);
                skipTyping = false;
            }
            else
            {

                yield return new WaitForSeconds(typingSpeed);
            }

        }
    }

}
