using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    #region Script's Summary
    //This script is managing game state
    #endregion

    #region Variable Declaration
    //--------------------Variable Declaration-----------------------------
    
    public Board board;
    public EnemyManager enemyManager;
    public int PlayerTurn = 5;
    public Text message;

    public bool isGameRunning = false;
    Player player;
    
    //----------------------------------------------------------------------
    #endregion

    #region Unity's method
    //----------------------Unity's Method----------------------------------

    void Awake () 
	{
        player = GetComponent<Player>();
        StartCoroutine(GameLoop());
    }

    //----------------------------------------------------------------------
    #endregion

    #region User's Functions
    //----------------------User's Functions--------------------------------

    public IEnumerator GameLoop()
    {
        yield return StartCoroutine(StartEvent());
        yield return StartCoroutine(RunEvent());
        yield return StartCoroutine(EndEvent());
    }

    IEnumerator StartEvent()
    {
        board.GenerateBoard();
        enemyManager.GenerateEnemies(board);
        player.InitPlayer(board, enemyManager);
        player.isTurn = true;
            
        isGameRunning = true;

        yield return new WaitForSeconds(1f);
    }

    IEnumerator RunEvent()
    {
        while (true)
        {
            if(player.hasPlayerWon(PlayerTurn, enemyManager.enemyCount))
            {
                message.text = "Player Won";
                yield break;
            }
            else if(player.hasPlayerLost(PlayerTurn, enemyManager.enemyCount))
            {
                message.text = "Player Lost";
                
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator EndEvent()
    {
        message.transform.parent.gameObject.SetActive(true);
        player.isTurn = false;
        yield return null;
    }
    
    //----------------------------------------------------------------------

    #endregion
}
