using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickToMove : MonoBehaviour
{
    #region Script Summary
    //--------------------------------------
    //this script is
    //--------------------------------------
    #endregion

    #region Variable Declaration
    //--------------------------------------
    
    //--------------------------------------
    #endregion

    #region Unity's Method
    //--------------------------------------
    
    //--------------------------------------
    #endregion

    #region User Methods
    //--------------------------------------
    
    public Node FindClickedNode(Vector3 position, Board board)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            if (hit.collider.transform.parent.GetComponent<Node>())
            {
                Node node = hit.collider.transform.parent.GetComponent<Node>();

                foreach (var n in board.nodes)
                {
                    if (n == node)
                    {
                        return node;
                    }
                }
            }
        }
        return null;
    }

    //--------------------------------------
    #endregion
}
