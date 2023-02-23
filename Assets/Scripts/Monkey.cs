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
    public int action { get; set; } //ENCAPSULATION
    public string firstAbility { get; set; }//ENCAPSULATION
    public string secondAbility { get; set; }//ENCAPSULATION
    public string thirdAbility { get; set; }//ENCAPSULATION
    public string fourthAbility { get; set; }//ENCAPSULATION
    public int critMultiplier  { get; set; }//ENCAPSULATION
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
    
    public  void PlayerActions(int action)//ABSTRACTION
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
    protected abstract void AbilityNames();//ABSTRACTION
    protected abstract void FirstAction();//ABSTRACTION
    protected abstract void SecondAction();//ABSTRACTION
    protected abstract void ThirdAction();//ABSTRACTION
    protected abstract void FourthAction();//ABSTRACTION
    public void HealthBar()//ABSTRACTION
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<HealtBar>();
    }
    public void SetEnemy()//ABSTRACTION
    {
        enemy = GameObject.Find("diaulo").GetComponent<Enemy>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public float CritCalculator()//ABSTRACTION
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
