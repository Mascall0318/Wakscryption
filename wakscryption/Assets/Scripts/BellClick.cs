using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellClick : MonoBehaviour
{
    private GameManager gameManager;
    bool isClicked;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>(); // 게임매니저 찾기
    }

    void Update()
    {
        // 마우스 클릭시
        if (Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // 마우스포인터 방향으로 ray 발사

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    isClicked = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isClicked)
        {
            gameManager.PlayerAttackButton();// 함수호출
            isClicked = false; // 클릭 상태 해제
        }
    }
}
