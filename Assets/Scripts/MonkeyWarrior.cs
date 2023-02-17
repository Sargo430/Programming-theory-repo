using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyWarrior : Monkey
{
    // Start is called before the first frame update
    protected override void ClassStats()
    {
        playerLife = 25;
        playerMaxLife = 25;
        playerDefence = 8;
        playerDamage = 7;
        playerCritChance = 50;
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
    protected override void AbilityNames()
    {
        firstAbility = "Machete cut";
        secondAbility = "WarCry";
        thirdAbility = "Rock Throw";
        fourthAbility = "Endure";

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
        playerDefence += 1;
        playerDamage+= 2;
        gameManager.PlayerTurnEnd();
    }
    protected override void ThirdAction()

    {
        if (!enemy.ignoreDamage)
        {
            enemy.enemyHealth -= (Mathf.RoundToInt(playerDamage/2) * CritCalculator() - enemy.enemyDefence);
            gameManager.isEnemyTurnSkipped = true;

        }
        else
        {
            enemy.ignoreDamage = false;
        }  
        gameManager.PlayerTurnEnd();
    }
    protected override void FourthAction()
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
