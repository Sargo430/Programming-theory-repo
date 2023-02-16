using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public bool isEnemyTurn;
    public bool isEnemyTurnSkipped;
    private Monkey monkey;
    private Enemy enemy;
    public bool isGameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI fightResultText;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver= false;
        monkey = GameObject.Find("Player").GetComponent<Monkey>();
        enemy = GameObject.Find("diaulo").GetComponent<Enemy>();
        isPlayerTurn = true;
        isEnemyTurnSkipped= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            if (!isEnemyTurnSkipped) 
            {
                EnemyTurn();
                
            }
            else
            {
                EnemyTurnEnd();
                isEnemyTurnSkipped= false;
            }
            
        }
        if (monkey.playerLife <= 0 )
        {
            gameOverText.color = Color.red;
            fightResultText.color = Color.red;
            fightResultText.text = "You lose";
            GameOver();
        }
        if(enemy.enemyHealth<= 0 )
        {
            gameOverText.color = Color.green;
            fightResultText.color = Color.green;
            fightResultText.text = "You win";
            GameOver();
        }
    }
    public void PlayerTurn()
    {
        isPlayerTurn= true;
    }
    public void PlayerTurnEnd()
    {
        isPlayerTurn= false;
        isEnemyTurn= true;
    }
    public void EnemyTurn()
    {
        isEnemyTurn= true;
    }
    public void EnemyTurnEnd()
    {
        isEnemyTurn= false;
        isPlayerTurn = true;

    }
    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
