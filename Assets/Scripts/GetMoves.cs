using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoves : MonoBehaviour
{
    #region Script Summary
    //--------------------------------------
    //this script is finding the valid moves of a player
    //--------------------------------------
    #endregion

    #region Variable Declaration
    //--------------------------------------

    public static readonly Vector2[] neighbourPosition = new Vector2[]
    {
        new Vector2(0,1),
        new Vector2(1,1),
        new Vector2(1,0),
        new Vector2(1,-1),
        new Vector2(0,-1),
        new Vector2(-1,-1),
        new Vector2(-1,0),
        new Vector2(-1,1)
    };
    public static readonly Vector2 rightPosition = new Vector2(1, 0);
    public static readonly Vector2 leftPosition = new Vector2(-1, 0);
    public static readonly Vector2 upPosition = new Vector2(0, 1);
    public static readonly Vector2 downPosition = new Vector2(0, -1);

    //--------------------------------------
    #endregion
    
}
