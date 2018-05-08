using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceInfo : MonoBehaviour
{

    public int x;
    public int y;
    public int color;

    /// <summary>
    /// 0なら色が変わり、1か2ならそれに応じた色になる
    /// </summary>
    /// <param name="color"></param>
    public void TurnPiece(int c = 0)
    {
        switch (c)
        {
            case 0:
                if (color == 1)
                {
                    color = 2;
                }
                else
                {
                    color = 1;
                }
                break;
            case 1:
                color = 1;
                break;
            case 2:
                color = 2;
                break;

        }
        //見た目を更新する。
        GetComponent<PieceView>().UpdateView();
    }

}
