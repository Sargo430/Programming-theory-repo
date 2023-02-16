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
        
        
    }
    protected override void SecondAction()
    {
        
    }
    protected override void ThirdAction()
    {
        
    }
    protected override void FourthAction()
    {
        
    }
}
