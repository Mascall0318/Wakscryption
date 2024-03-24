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
        // 전투 시작
        BattleStart();
    }


    void BattleStart() {
        // 전투 시작시 캐릭터 등장 애니메이션 등 효과 넣기

            // 플레이어나 적에게 턴 넘기기
        state = EState.playerturn; 
        // 플레이어 턴
    }

    // 공격버튼
    public void PlayerAttackButton() {

        RaycastHit hitInfo = new RaycastHit();

        if(state != EState.playerturn ) {
            return; 
            // 플레이어 턴이 아닐때 계속 눌리는거 방지
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack() {
        yield return new WaitForSeconds(1f);
        Debug.Log("플레이어 공격");
        // 공격 스킬, 데미지 등


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
        Debug.Log("전투 종료");
    }

    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(1f);
        // 적 공격 코드

        state = EState.playerturn;
    }
}
