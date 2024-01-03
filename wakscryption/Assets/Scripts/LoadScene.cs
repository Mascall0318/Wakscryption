using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string creditScene;
    public string settingScene;
    public string TitleScene;

    public void EnterCredit()
    {
        LoadingScene(creditScene);
    }

    public void EnterSetting()
    {
        LoadingScene(settingScene);
    }

    public void EnterTitle()
    {
        LoadingScene(TitleScene);
    }


    public void LoadingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
