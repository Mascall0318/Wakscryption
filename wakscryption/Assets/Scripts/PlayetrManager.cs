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
    float idongguri = 10; //�̵��Ÿ�
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
    TMP_InputField playergogae; //�÷��̾��� rotation X ���� ��ǲ
    [SerializeField]
    TMP_InputField playerki; //�÷��̾��� Ű
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
            percent = currentTime / kaiten_speed; // fadeTime�� � ��ǻ�Ϳ��� �����ϴ��� ������ ���� ���� �� �ְ� ����� percent
            float rrotaion;
            rrotaion = Mathf.Lerp(start, end, percent);
            transform.rotation = Quaternion.Euler(0, rrotaion, 0);

            yield return null;
        }
        rotaion = end;
        realrotaion = rotaion;
    }

    IEnumerator idong(bool foward) //��ȹ : ai ���̵�� : ai �ڵ� �ۼ� : ai �ڵ� ���� : �ΰ�.
    { //158
        float journey = 0f; // �ʱ� �̵� �Ÿ��� 0���� �����մϴ�.
        Vector3 start = P2.transform.position; // ���� ��ġ�� ���� ��ġ�� �����մϴ�.
        Vector3 end = foward ? start + P2.transform.forward * idongguri : start - P2.transform.forward * idongguri;
        P3.transform.position = end;
        P2.transform.position = P3.transform.position;
        while (journey <= 1f) // �̵� �Ÿ��� 1�� �� ������ �ݺ��մϴ�.
        {
            journey += Time.deltaTime * move_speed; // �̵� �Ÿ��� �ð��� ���� ������ŵ�ϴ�.
            transform.position = Vector3.Lerp(start, end, journey); // ���� ��ġ�� ��ǥ ��ġ ���̸� �̵� �Ÿ� ������ŭ �̵��մϴ�.
            yield return null;
        }
        transform.position = P3.transform.position;
    }
}