using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMage : Monkey
{

    protected override void ClassStats()
    {
        playerLife = 10;
        playerMaxLife = 10;
        playerDefence = 5;
        playerDamage = 10;
    }
    void Start()
    {
        SetEnemy();
        HealthBar();
        ClassStats();
        AbilityNames();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.UpdateHealthBar();
    }
    protected override void AbilityNames()
    {
        firstAbility = "Machete Rain";
        secondAbility = "Energy shield";
        thirdAbility = "Vine binding";
        fourthAbility = "Health wish";
        
    }
    protected override void FirstAction()
    {
        if (!enemy.ignoreDamage)
        {
            enemy.enemyHealth -= (playerDamage * CritCalculator() - enemy.enemyDefence);
            
        }
        else
        {
            enemy.ignoreDamage = false;
        }
        
        gameManager.PlayerTurnEnd();
        
    }
    protected override void SecondAction()
    {
        playerDefence += 3;
        gameManager.PlayerTurnEnd();
    }
    protected override void ThirdAction()

    {
        gameManager.isEnemyTurnSkipped = true;
        gameManager.PlayerTurnEnd();
    }
    protected override void FourthAction()
    {
        if(playerLife < playerMaxLife)
        {
            playerLife += 5;
            if(playerLife > playerMaxLife)
            {
                playerLife= playerMaxLife;
            }
        }
        else
        {
            Debug.Log("You are already fully healed");
        }
        gameManager.PlayerTurnEnd();

    }
}
