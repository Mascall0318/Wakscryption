using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Texture")]
    public Texture2D clickUpTexture;
    public Texture2D clickDownTexture;
    public Texture2D arrowDownTexture;
    public Texture2D arrowUpTexture;

    private Texture2D currentTexture;

    [Header("Cursor Blink Interval")]
    public float mouseBlinkInterval = 0.2f;

    private bool isMouseUp = true;
    private bool isChanging = false;

    [Header("Hotspot")]
    public Vector2 defaltHotspot = new Vector2(24,4);
    public Vector2 arrowHotspot = new Vector2(64,-128);

    private Coroutine changingCoroutine;

    IEnumerator CursorChanging()
    {
        while (true)
        {
            if (isChanging)
            {
                Cursor.SetCursor(isMouseUp ? clickUpTexture : clickDownTexture, Vector2.zero, CursorMode.Auto);
                isMouseUp = !isMouseUp;
            }
            yield return new WaitForSeconds(mouseBlinkInterval);
        }
    }

    public void SetDefaltCursor()
    {
        Cursor.SetCursor(null, defaltHotspot, CursorMode.Auto);
    }

    public void ClickDown()
    {
        isChanging = false;
        Cursor.SetCursor(clickDownTexture, defaltHotspot, CursorMode.Auto);
    }

    public void ClickUp()
    {
        isChanging = true;
        Cursor.SetCursor(clickUpTexture, defaltHotspot, CursorMode.Auto);
    }

    public void StartChanging() {
        if (changingCoroutine != null)
        {
            StopCoroutine(changingCoroutine); 
            isChanging = false;
        }
        StartCoroutine(CursorChanging());
        isChanging = true;
    }

    public void StopChanging()
    {
        if (changingCoroutine != null)
        {
            StopCoroutine(CursorChanging());
        }
        isChanging = false;
        SetDefaltCursor();
    }

    public void ArrowDown()
    {
        Cursor.SetCursor(arrowDownTexture, arrowHotspot, CursorMode.Auto);
    }

    public void ArrowUp()
    {
        Cursor.SetCursor(arrowUpTexture, arrowHotspot, CursorMode.Auto);
    }
}
