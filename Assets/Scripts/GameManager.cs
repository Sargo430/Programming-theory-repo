using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public bool isEnemyTurn;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
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
            EnemyTurn();
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
}
