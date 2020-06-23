using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Script Summary
    //--------------------------------------
    //this script is
    //--------------------------------------
    #endregion

    #region Variable Declaration
    //--------------------------------------

    public int enemyCount = 5;
    Board m_board;

    //--------------------------------------
    #endregion

    #region Unity's Method
    //--------------------------------------
    
    //--------------------------------------
    #endregion

    #region User Methods
    //--------------------------------------
    
    public void GenerateEnemies(Board board)
    {
        if (board == null)
            return;

        m_board = board;

        for (int i = 0; i < enemyCount; i++)
        {
            m_board.GenerateEnemies();
        }
    }

    public bool DidEnemyExist(Node node)
    {
        if (node && m_board)
        {
            if (m_board.enemyNodes.Contains(node))
            {
                return true;
            }
        }
        return false;
    }
    public bool DidEnemyExistNearby(Node node)
    {
        if (node && m_board)
        {
            foreach (var enemy in m_board.enemyNodes)
            {
                if (node.neighbours.Contains(enemy))
                {
                    return true;
                }
            }
        }
        return false;
    }



    //--------------------------------------
    #endregion
}
