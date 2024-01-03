using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    [SerializeField]
    public Dropdown resolutionDropdown;
    [SerializeField]
    public Toggle fullScreenToggle;

    public static bool isFullScreen;

    public static ChangeResolution Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        LoadUIState();

        resolutionDropdown.onValueChanged.AddListener(delegate { ResolutionChanger(isFullScreen); SaveUIState(); });
        fullScreenToggle.onValueChanged.AddListener(FullScreenModeChanger);
    }

    public void ResolutionChanger(bool fullScreenValue)
    {
        switch (resolutionDropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, fullScreenValue);
                break;
            case 1:
                Screen.SetResolution(1600, 900, fullScreenValue);
                break;
            case 2:
                Screen.SetResolution(1280, 720, fullScreenValue);
                break;
        }

        FullScreenModeChanger(isFullScreen);
        SaveUIState();
    }

    public void FullScreenModeChanger(bool isFullScreenMode)
    {
        if (isFullScreenMode)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        SaveUIState();
    }

    public void SaveUIState()
    {
        int fullScreenState = fullScreenToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreen", fullScreenState);
        PlayerPrefs.Save();
    }

    public void LoadUIState()
    {
        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = resolutionIndex;

        int fullScreen = PlayerPrefs.GetInt("FullScreen", 0);
        isFullScreen = fullScreen == 1;
        fullScreenToggle.isOn = isFullScreen;
        ResolutionChanger(isFullScreen);
    }


}
