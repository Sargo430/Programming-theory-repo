using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyRanger : Monkey//INHERITANCE
{
    protected override void ClassStats()
    {
        playerLife = 15;
        playerMaxLife = 15;
        playerDefence = 7;
        playerDamage = 8;
        playerCritChance = 75;
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
        firstAbility = "Machete Arrow";
        secondAbility = "Head shot";
        thirdAbility = "Hunter instict";
        fourthAbility = "Medical Herbs";

    }
    protected override void FirstAction()// POLYMORPHISM
    {
        if (!enemy.ignoreDamage)
        {
            enemy.enemyHealth -= playerDamage * CritCalculator() - enemy.enemyDefence;

        }
        else
        {
            enemy.ignoreDamage = false;
        }

        gameManager.PlayerTurnEnd();

    }
    protected override void SecondAction()// POLYMORPHISM
    {
        enemy.enemyHealth-= playerDamage * 2;
        gameManager.PlayerTurnEnd();
    }
    protected override void ThirdAction()// POLYMORPHISM

    {
        playerDamage+= 5;
        gameManager.PlayerTurnEnd();
    }
    protected override void FourthAction()// POLYMORPHISM
    {
        if (playerLife < playerMaxLife)
        {
            playerLife += 5;
            if (playerLife > playerMaxLife)
            {
                playerLife = playerMaxLife;
            }
        }
        else
        {
            Debug.Log("You are already fully healed");
        }
        gameManager.PlayerTurnEnd();

    }
}
