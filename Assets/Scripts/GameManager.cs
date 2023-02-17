using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private MainManager mainManager;
    public GameObject[] clasees;
    private GameObject player;
    

    // Start is called before the first frame update
    void Awake()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        ClassSelected();
        isGameOver = false;
        
        monkey = GameObject.Find("Player").GetComponent<Monkey>();
        enemy = GameObject.Find("diaulo").GetComponent<Enemy>();
        isPlayerTurn = true;
        isEnemyTurnSkipped= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (isPlayerTurn)
            {
                CheckGameOver();
                PlayerTurn();
            }
            else
            {
                CheckGameOver();
                if (!isEnemyTurnSkipped)
                {

                    EnemyTurn();

                }
                else
                {

                    EnemyTurnEnd();
                    isEnemyTurnSkipped = false;
                }

            }
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
    public void ClassSelected()
    {
        switch (mainManager.classSelected)
        {
            case 0:
                {
                    Instantiate(clasees[mainManager.classSelected]);
                    player = GameObject.Find("Mage(Clone)");
                    player.name = "Player";
                    return;
                }
            case 1:
                {
                    Instantiate(clasees[mainManager.classSelected]);
                    player = GameObject.Find("Ranger(Clone)");
                    player.name = "Player";
                    return;
                }
            case 2:
                {
                    Instantiate(clasees[mainManager.classSelected]);
                    player = GameObject.Find("Warrior(Clone)");
                    player.name = "Player";
                    return;
                }
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void CheckGameOver()
    {
        if (monkey.playerLife <= 0)
        {
            isGameOver= true;
            gameOverText.color = Color.red;
            fightResultText.color = Color.red;
            fightResultText.text = "You lose";
            GameOver();
        }
        if (enemy.enemyHealth <= 0)
        {
            isGameOver= true;
            gameOverText.color = Color.green;
            fightResultText.color = Color.green;
            fightResultText.text = "You win";
            GameOver();
        }
    }
}
