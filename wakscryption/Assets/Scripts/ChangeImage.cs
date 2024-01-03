using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Button button;
    public float verticalScaleFactor = 2f;
    public float originalScaleFactor;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Image image = button.GetComponent<Image>();

        RectTransform rectTransform = image.rectTransform;
        Vector2 originalSize = rectTransform.sizeDelta;

        rectTransform.sizeDelta = new Vector2(originalSize.x, originalSize.y * verticalScaleFactor);
    }

    public void ResetImage()
    {
        originalScaleFactor = 1/verticalScaleFactor;

        Image image = button.GetComponent<Image>();

        RectTransform rectTransform = image.rectTransform;
        Vector2 originalSize = rectTransform.sizeDelta;

        rectTransform.sizeDelta = new Vector2(originalSize.x, originalSize.y * originalScaleFactor);
    }
}
