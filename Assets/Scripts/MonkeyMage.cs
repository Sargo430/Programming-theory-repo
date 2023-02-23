using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMage : Monkey //INHERITANCE
{

    protected override void ClassStats()
    {
        playerLife = 10;
        playerMaxLife = 10;
        playerDefence = 5;
        playerDamage = 10;
    }
    void Awake()
    {
        AbilityNames();
        SetEnemy();
        HealthBar();
        ClassStats();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.UpdateHealthBar();
    }
    protected override void AbilityNames()// POLYMORPHISM
    {
        firstAbility = "Machete Rain";
        secondAbility = "Energy shield";
        thirdAbility = "Vine binding";
        fourthAbility = "Health wish";
        
    }
    protected override void FirstAction()// POLYMORPHISM
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
    protected override void SecondAction()// POLYMORPHISM
    {
        playerDefence += 3;
        gameManager.PlayerTurnEnd();
    }
    protected override void ThirdAction()// POLYMORPHISM

    {
        gameManager.isEnemyTurnSkipped = true;
        gameManager.PlayerTurnEnd();
    }
    protected override void FourthAction()// POLYMORPHISM
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
