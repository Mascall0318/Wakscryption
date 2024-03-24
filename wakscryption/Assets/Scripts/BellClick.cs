using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellClick : MonoBehaviour
{
    private GameManager gameManager;
    bool isClicked;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>(); // ���ӸŴ��� ã��
    }

    void Update()
    {
        // ���콺 Ŭ����
        if (Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // ���콺������ �������� ray �߻�

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == gameObject) {
                    isClicked = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isClicked)
        {
            gameManager.PlayerAttackButton();// �Լ�ȣ��
            isClicked = false; // Ŭ�� ���� ����
        }
    }
}
