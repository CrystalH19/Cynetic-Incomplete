using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject player;
    public GameObject enemy;

    public Transform playerShadow;
    public Transform enemyShadow;

    unit playerUnit;
    unit enemyUnit;

    public TMP_Text dialogue;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Button attackbtn;
    public Button healbtn;

    public string nextScene;
    public string pastScene;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

        attackbtn.enabled = false;
        healbtn.enabled = false;
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(player, playerShadow);
        playerUnit = playerGo.GetComponent<unit>();
        GameObject enemyGo = Instantiate(enemy, enemyShadow);
        enemyUnit = enemyGo.GetComponent<unit>();

        dialogue.text = enemyUnit.unitName + " suddenly starts attacking!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        attackbtn.enabled = true;
        healbtn.enabled = true;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogue.text = "What will you do?";
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage();

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogue.text = playerUnit.unitName + " attacks!";

        attackbtn.enabled = false;
        healbtn.enabled = false;

        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        { 
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator playerHeal()
    {
        playerUnit.heal();
        playerHUD.SetHP(playerUnit.currentHP);
        dialogue.text = playerUnit.unitName + " healed themself.";
        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyTurn());

    }

    private int healTurn = 0;
    IEnumerator EnemyTurn()
    {
        if (enemyUnit.currentHP <= (enemyUnit.maxHP/2))
        {
            if (healTurn >= 2)
            {
                dialogue.text = enemyUnit.unitName + " attacks!";
                yield return new WaitForSeconds(1f);

                bool isDead = playerUnit.TakeDamage();
                playerHUD.SetHP(playerUnit.currentHP);

                if (isDead)
                {
                    state = BattleState.LOST;
                    //Debug.Log("lost");
                    EndBattle();
                }
                else
                {
                    state = BattleState.PLAYERTURN;
                    attackbtn.enabled = true;
                    healbtn.enabled = true;
                    PlayerTurn();

                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                dialogue.text = enemyUnit.unitName + " healed itself!";
                yield return new WaitForSeconds(1f);
                enemyUnit.heal();
                enemyHUD.SetHP(enemyUnit.currentHP);
                healTurn += 1;

                state = BattleState.PLAYERTURN;
                attackbtn.enabled = true;
                healbtn.enabled = true;
                PlayerTurn();

                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            dialogue.text = enemyUnit.unitName + " attacks!";
            yield return new WaitForSeconds(1f);

            bool isDead = playerUnit.TakeDamage();
            playerHUD.SetHP(playerUnit.currentHP);

            if (isDead)
            {
                state = BattleState.LOST;
                //Debug.Log("lost");
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;
                attackbtn.enabled = true;
                healbtn.enabled = true;
                PlayerTurn();

                yield return new WaitForSeconds(1f);
            }

        }
        
    }

    public void onAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    public void onHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(playerHeal());
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogue.text = playerUnit.unitName + " defeated " + enemyUnit.unitName;
            Initiate.Fade(nextScene, Color.black, 0.5f);
        }
        else if (state == BattleState.LOST)
        {
            dialogue.text = enemyUnit.unitName + " defeated " + playerUnit.unitName + ". You start to black out.";
            Initiate.Fade(pastScene, Color.black, 0.5f);
        }
    }
}
