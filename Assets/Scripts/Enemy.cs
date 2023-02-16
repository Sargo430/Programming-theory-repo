using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Image healthBarImage;
    public TextMeshProUGUI healthText;
    public float enemyMaxHealth = 50;
    public float enemyHealth = 50;
    public int enemyAttack = 10;
    public int enemyDefence = 7;
    private GameManager gameManager;
    private Monkey monkey;
    private int enemyDamageDealth;
    public bool ignoreDamage;
    void Start()
    {
        monkey = GameObject.Find("Player").GetComponent<Monkey>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyHealthBar();
        if (gameManager.isEnemyTurn)
        {
            EnemyAction();
        }
    }
    public void UpdateEnemyHealthBar()
    {
        healthText.text = $"HP:{enemyHealth}/{enemyMaxHealth}";
        healthBarImage.fillAmount = Mathf.Clamp(enemyHealth / enemyMaxHealth, 0, 1f);
    }
    void EnemyAction()
    {
        int enemyAction = Random.Range(1, 4);
        switch (enemyAction)
        {
            case 1: 
                {
                    enemyDamageDealth = enemyAttack - monkey.playerDefence;
                    if(enemyDamageDealth < 0)
                    {
                        enemyDamageDealth= 0;
                    }
                    monkey.playerLife -= enemyDamageDealth;
                    gameManager.EnemyTurnEnd();
                    return;
                }
                case 2:
                {
                    enemyDamageDealth = enemyAttack - (monkey.playerDefence- Mathf.RoundToInt(monkey.playerDefence/2));
                    if (enemyDamageDealth < 0)
                    {
                        enemyDamageDealth = 0;
                    }
                    monkey.playerLife -= enemyDamageDealth;
                    gameManager.EnemyTurnEnd();
                    return;
                }
                case 3:
                {
                    ignoreDamage= true;
                    gameManager.EnemyTurnEnd();
                    return;
                }
        }
    }
    
}
