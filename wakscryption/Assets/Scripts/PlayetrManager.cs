using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayetrManager : MonoBehaviour
{
    [SerializeField]
    float kaiten_speed = 0.001f;
    [SerializeField]
    float move_speed = 0.001f;
    [SerializeField]
    float idongguri = 10; //이동거리
    int rotaion = 0;
    int realrotaion = 0;
    [SerializeField]
    GameObject EscCanvas;
    [SerializeField]
    GameObject SettingCanvas;
    [SerializeField]
    GameObject realygameout;
    public GameObject P3;
    public GameObject P2;
    [SerializeField]
    Texture2D fingercursor;
    [SerializeField]
    Texture2D fingercursorclick;
    [SerializeField]
    Texture2D normalcursor;
    [SerializeField]
    GameObject dialogue;
    [SerializeField]
    TMP_InputField idongspeed;
    [SerializeField]
    TMP_InputField playergogae; //플레이어의 rotation X 조절 인풋
    [SerializeField]
    TMP_InputField playerki; //플레이어의 키
    bool esc = false;
    bool gaot = false;
    bool setcan = false;
    bool dialoguesee = false;

    void Update()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "text object" && !esc)
                {
                    if (Input.GetMouseButton(0))
                    {
                        Cursor.SetCursor(fingercursorclick, Vector2.zero, CursorMode.Auto);
                    }
                    else
                    {
                        Cursor.SetCursor(fingercursor, Vector2.zero, CursorMode.Auto);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        dialoguesee = !dialoguesee;
                    }
                }
                else
                {
                    Cursor.SetCursor(normalcursor, Vector2.zero, CursorMode.Auto);
                }
        }
        idongguri = float.Parse(idongspeed.text);
        P2.transform.position = new Vector3(P2.transform.position.x, float.Parse(playerki.text), P2.transform.position.z);
        P3.transform.position = new Vector3(P3.transform.position.x, float.Parse(playerki.text), P3.transform.position.z);
        transform.position = new Vector3(transform.position.x, float.Parse(playerki.text), transform.position.z);
        P2.transform.rotation = Quaternion.Euler(0, realrotaion, 0);
        P3.transform.rotation = Quaternion.Euler(0, realrotaion, 0);
        if (Input.GetKeyDown(KeyCode.D) && !esc)
        {
            StartCoroutine(rotation(true));
        }

        if (Input.GetKeyDown(KeyCode.W) && !esc)
        {
            StartCoroutine(idong(true));

        }
        if (Input.GetKeyDown(KeyCode.S) && !esc)
        {
            StartCoroutine(idong(false));
        }

        if (Input.GetKeyDown(KeyCode.A) && !esc)
        {
            StartCoroutine(rotation(false));
        }
        if (Input.GetKeyDown(KeyCode.R) && !esc)
        {
            transform.rotation = Quaternion.Euler(float.Parse(playergogae.text), realrotaion, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gaot || setcan)
            {
                gaot = false;
                setcan = false;
            }
            else
            {
                esc = !esc;
            }
        }
        EscCanvas.SetActive(esc);
        realygameout.SetActive(gaot);
        SettingCanvas.SetActive(setcan);
        dialogue.SetActive(dialoguesee);
        if (esc)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void continueee()
    {
        if (!setcan)
        {
            esc = false;
        }
    }

    public void timescale0()
    {
        esc = false;
        Time.timeScale = 1;
    }

    public void gameout()
    {
        gaot = !gaot;
    }
    public void setting()
    {
        setcan = !setcan;
    }

    IEnumerator rotation(bool right)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        int start = rotaion;
        int end = right ? rotaion + 90 : rotaion - 90;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / kaiten_speed; // fadeTime을 어떤 컴퓨터에서 실행하더라도 일정한 값이 나올 수 있게 만든게 percent
            float rrotaion;
            rrotaion = Mathf.Lerp(start, end, percent);
            transform.rotation = Quaternion.Euler(0, rrotaion, 0);

            yield return null;
        }
        rotaion = end;
        realrotaion = rotaion;
    }

    IEnumerator idong(bool foward) //기획 : ai 아이디어 : ai 코드 작성 : ai 코드 수정 : 인간.
    { //158
        float journey = 0f; // 초기 이동 거리를 0으로 설정합니다.
        Vector3 start = P2.transform.position; // 시작 위치를 현재 위치로 설정합니다.
        Vector3 end = foward ? start + P2.transform.forward * idongguri : start - P2.transform.forward * idongguri;
        P3.transform.position = end;
        P2.transform.position = P3.transform.position;
        while (journey <= 1f) // 이동 거리가 1이 될 때까지 반복합니다.
        {
            journey += Time.deltaTime * move_speed; // 이동 거리를 시간에 따라 증가시킵니다.
            transform.position = Vector3.Lerp(start, end, journey); // 시작 위치와 목표 위치 사이를 이동 거리 비율만큼 이동합니다.
            yield return null;
        }
        transform.position = P3.transform.position;
    }
}