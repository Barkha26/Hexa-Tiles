using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Rook,
    Bishop,
    Knight
}

[RequireComponent(typeof(ClickToMove))]
public class Player : MonoBehaviour
{
    #region Script Summary
    //--------------------------------------
    //this script is managing the player
    //--------------------------------------
    #endregion

    #region Variable Declaration
    //--------------------------------------

    public bool isTurn = false;
    public bool hasWon = false;
    [HideInInspector]
    public int turnCount = 0;
    [HideInInspector]
    public int enemyCount = 0;
    public Color turnColor;


    ClickToMove m_clickToMove;
    GetMoves m_getMoves;
    Board m_board;
    EnemyManager m_enemyManager;
    Node currentNode = null;

    //--------------------------------------
    #endregion

    #region Unity's Method
    //--------------------------------------

    void Awake()
    {
        m_clickToMove = GetComponent<ClickToMove>();
    }

    public void InitPlayer(Board b, EnemyManager em)
    {
        m_board = b;
        m_enemyManager = em;

        currentNode = m_board.IsValidNode(Vector2.zero);
        currentNode.DisplayTurn(true, turnColor);
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && isTurn)
        //{
        //    Node node = m_clickToMove.FindClickedNode(Input.mousePosition, m_board);

        //    if (node != null && !node.isOpen)
        //    {
        //        HighlightNode(node);
        //        turnCount++;
        //    }
        //}
        if (!isTurn) return;

        Node newNode = null;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            newNode = m_board.IsValidNode(
                new Vector2(currentNode.xIndex + GetMoves.upPosition.x, 
                currentNode.yIndex + GetMoves.upPosition.y));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            newNode = m_board.IsValidNode(
                new Vector2(currentNode.xIndex + GetMoves.rightPosition.x,
                currentNode.yIndex + GetMoves.rightPosition.y));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            newNode = m_board.IsValidNode(
               new Vector2(currentNode.xIndex + GetMoves.downPosition.x,
               currentNode.yIndex + GetMoves.downPosition.y));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            newNode = m_board.IsValidNode(
               new Vector2(currentNode.xIndex + GetMoves.leftPosition.x,
               currentNode.yIndex + GetMoves.leftPosition.y));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!currentNode.isOpen)
            {
                HighlightNode(currentNode);
                turnCount++;
            }
        }

        if (newNode != null)
        {
            currentNode.DisplayTurn(false, Color.white);
            currentNode = newNode;
            currentNode.DisplayTurn(true, turnColor);
        }


    }

    //--------------------------------------
    #endregion

    #region User Methods
    //--------------------------------------

    void HighlightNode(Node node)
    {
        if (!node.isOpen)
        {
            if (m_enemyManager.DidEnemyExist(node))
            {
                node.HighlightNode(m_board.enemyColor);
                enemyCount++;
            }
            else if (m_enemyManager.DidEnemyExistNearby(node))
            {
                node.HighlightNode(m_board.nearByColor);
            }
            else
            {
                node.HighlightNode(m_board.farColor);
            }
        }
    }

    public bool hasPlayerWon(int totalTurn, int totalEnemies)
    {
        if (turnCount <= totalTurn && enemyCount >= totalEnemies)
            return true;

        return false;
    }

    public bool hasPlayerLost(int totalTurn, int totalEnemies)
    {
        if (turnCount >= totalTurn && enemyCount < totalTurn)
            return true;

        return false;
    }

    //--------------------------------------
    #endregion
}
