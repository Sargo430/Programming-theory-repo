using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monkey : MonoBehaviour
{
    public HealtBar healthbar;
    public float playerLife = 10;
    public float playerMaxLife = 10;
    public int playerDamage = 10;
    public int playerDefence = 10;
    public int playerCritChance = 30;
    public int action;
    public string firstAbility;
    public string secondAbility;
    public string thirdAbility;
    public string fourthAbility;
    public int critMultiplier;
    public Enemy enemy;
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected abstract void ClassStats();
    
    public  void PlayerActions(int action)
    {
        switch (action)
        {
            case 1:
                {
                    
                    FirstAction();
                    return;
                }
            case 2:
                {
                    SecondAction();
                    return;
                }
            case 3:
                {
                    ThirdAction();
                    return;
                }
            case 4:
                {
                    FourthAction();
                    return;
                }
        }
    }
    protected abstract void AbilityNames();
    protected abstract void FirstAction();
    protected abstract void SecondAction();
    protected abstract void ThirdAction();
    protected abstract void FourthAction();
    public void HealthBar()
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<HealtBar>();
    }
    public void SetEnemy()
    {
        enemy = GameObject.Find("diaulo").GetComponent<Enemy>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public float CritCalculator()
    {
        int critRandom = Random.Range(0, 100);
        if (critRandom <= playerCritChance)
        {
            critMultiplier = 2;
        }
        else
        {
            critMultiplier= 1;
        }
        return critMultiplier;
    }

  
     
}
