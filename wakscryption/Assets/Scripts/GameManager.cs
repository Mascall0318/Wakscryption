using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public enum EState {
        start, 
        playerturn, 
        enemyturn, 
        win
    }

    public EState state;
    public bool IsLive; 

    void Awake() {
        state = EState.start; 
        // ���� ����
        BattleStart();
    }


    void BattleStart() {
        // ���� ���۽� ĳ���� ���� �ִϸ��̼� �� ȿ�� �ֱ�

            // �÷��̾ ������ �� �ѱ��
        state = EState.playerturn; 
        // �÷��̾� ��
    }

    // ���ݹ�ư
    public void PlayerAttackButton() {

        RaycastHit hitInfo = new RaycastHit();

        if(state != EState.playerturn ) {
            return; 
            // �÷��̾� ���� �ƴҶ� ��� �����°� ����
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack() {
        yield return new WaitForSeconds(1f);
        Debug.Log("�÷��̾� ����");
        // ���� ��ų, ������ ��


        if (!IsLive) {
            state = EState.win;
            EndBattle();
        }
        else {
            state = EState.enemyturn;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle() {
        Debug.Log("���� ����");
    }

    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(1f);
        // �� ���� �ڵ�

        state = EState.playerturn;
    }
}
