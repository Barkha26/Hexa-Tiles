using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour 
{
    #region Script's Summary
    //This script is generating the game board
    #endregion

    #region Variable Declaration
    //--------------------Variable Declaration-----------------------------

    public GameObject tilePrefab;

    public int width = 4;
    public int height = 4;

    public float border = 0.1f;

    public Color normalColor = Color.white;
    public Color nearByColor = Color.green;
    public Color enemyColor = Color.red;
    public Color farColor = Color.red;

    public Node[,] nodes;

    //[HideInInspector]
    public List<Node> enemyNodes;

    //----------------------------------------------------------------------
    #endregion

    #region User's Functions
    //----------------------User's Functions--------------------------------
    
    public void GenerateBoard()
    {
        nodes = new Node[height, width];

        if (!tilePrefab)
            return;
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject tileInstance = Instantiate(tilePrefab, 
                    new Vector3(x, 0, y), Quaternion.identity,transform);

                tileInstance.name = "Node (" + x + "," + y + ")";
                //tileInstance.transform.localScale = new Vector3(1 - border, 0, 1 - border);

                Node node = tileInstance.GetComponent<Node>();
                nodes[y, x] = node;

                if (node)
                {
                    node.InitNode(x,y, normalColor);
                }
            }
        }
        foreach (var node in nodes)
        {
            node.InitNeighbours();
        }
    }

    public Node IsValidNode(Vector2 position)
    {
        foreach (var n in nodes)
        {
            if (n.xIndex == position.x && n.yIndex == position.y)
            {
                return n;
            }
        }
        return null;
    }

    public void GenerateEnemies()
    {
        int randomHeight = -1;
        int randomWidth = -1;

        while (true)
        {
            randomHeight = Random.Range(0, height);
            randomWidth = Random.Range(0, width);

            Node enemyNode = IsValidNode(new Vector2(randomHeight, randomWidth));

            if (enemyNode && !enemyNodes.Contains(enemyNode))
            {
                enemyNodes.Add(enemyNode);
                
                break;
            }
        }
    }

    //----------------------------------------------------------------------

    #endregion
}
