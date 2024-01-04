using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateController : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("FullScreen"))
        {
            PlayerPrefs.SetInt("FullScreen", Screen.fullScreen ? 1 : 0);
            PlayerPrefs.Save();
        }
        //ChangeResolution.Instance.LoadUIState();
    }
}
