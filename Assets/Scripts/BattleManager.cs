using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleManager : MonoBehaviour
{
    RPSMenu HUD;

    [Header("Player")]
    public int playerMaxHealth;
    public int playerHealth;
    public int playerMaxMagic;
    public int playerMagic;
    public int playerDefense;
    public int playerAttack;

    [Header("Enemy")]
    public EnemyObject enemyData;
    public int enemyHealth;
    public int enemyDefense;
    public int enemyAttack;
    private int patternChosen;

    private void Start()
    {
        RandomPattern();

        HUD = GetComponent<RPSMenu>();
    }
    void RandomPattern() // Picks a random pattern out of the ones in the enemy object
    {
        patternChosen = UnityEngine.Random.Range(0, enemyData.patterns.Length);
    }

    public string RPSCheckAllTurns(string playerAttackSeq)
    {
        string battleResult = "";

        for(int i = 0; i < 6; i++)
        {
            char playerChoice = Char.ToLower(playerAttackSeq[i]);
            char enemyChoice = Char.ToLower(enemyData.patterns[patternChosen][i]);

            battleResult += RPSCheck1Turn(playerChoice, enemyChoice);
        }
        RandomPattern();
        return battleResult;
    }
    public char RPSCheck1Turn(char playerChoice,char enemyChoice)
    {
        if (playerChoice == enemyChoice)
        {
            return 'd';
        }
        else if (playerChoice == 'a' && enemyChoice == 'b')
        {
            enemyHealth -= 50;
            HUD.SetStats();
            return 'w';
            
        }
        else if (playerChoice == 'b' && enemyChoice == 'g')
        {
            return 'w';
        }
        else if (playerChoice == 'g' && enemyChoice == 'a')
        {
            return 'w';
        }
        else if (enemyChoice == 'a' && playerChoice == 'b')
        {
            return 'l';
        }
        else if (enemyChoice == 'b' && playerChoice == 'g')
        {
            return 'l';
        }
        else if (enemyChoice == 'g' && playerChoice == 'a')
        {
            return 'l';
        }
        return 'd';
    }
}
