using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    //Singletonというデザインパターンを用いて、簡単にStageManagerにアクセスできるようにする。
    public static StageManager Instance;

    //オセロの盤面を配列で保存する
    private PieceInfo[,] bord;

    //オセロのピースのprefab
    public GameObject piecePrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        MakeStage();
    }

    /// <summary>
    /// ピースを8*8に並べる
    /// </summary>
    private void MakeStage()
    {
        bord = new PieceInfo[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject piece = Instantiate(piecePrefab, new Vector3(i, j), Quaternion.identity) as GameObject;
                PieceInfo pieceInfo = piece.GetComponent<PieceInfo>();
                pieceInfo.x = i;
                pieceInfo.y = j;
                pieceInfo.color = 0;
                piece.GetComponent<PieceView>().UpdateView();
                bord[i, j] = pieceInfo;
            }
        }
    }

    /// <summary>
    /// 上下左右に揃っているか確認する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void CheckPieces(int x, int y)
    {
        //上のピースが2つ以上存在する
        if (y < 6)
        {
            Debug.Log("check");
            // 1. 隣のピースから順にピースの色を確認する（色が異なれば）
            int i = 1;
            while (bord[x, y + i].color != bord[x, y].color)
            {
                //一番上のピースを指しているか、ピースが置いなければそれ以上確認しない
                if (y + i == 7 || bord[x, y + i].color == 0)
                {
                    i = 0;
                    break;
                }

                i++;
            }

            Debug.Log(i);

            //bord[x, y + i] が真上方向にある一番近い同じ色のピースになる
            while (i > 1)
            {
                i--;
                bord[x, y + i].TurnPiece();
            }
        }

        //下バージョン
        if (y > 1)
        {
            // 1. 隣のピースから順にピースの色を確認する（色が異なれば）
            int i = 1;
            while (bord[x, y - i].color != bord[x, y].color)
            {
                //一番下のピースを指しているか、ピースが置いなければそれ以上確認しない
                if (y - i == 0 || bord[x, y - i].color == 0)
                {
                    i = 0;
                    break;
                }

                i++;
            }

            Debug.Log(i);

            //bord[x, y - i] が真下方向にある一番近い同じ色のピースになる
            while (i > 1)
            {
                i--;
                bord[x, y - i].TurnPiece();
            }
        }

        //右バージョン
        if (x < 6)
        {
            Debug.Log("check");
            // 1. 隣のピースから順にピースの色を確認する（色が異なれば）
            int i = 1;
            while (bord[x + i, y].color != bord[x, y].color)
            {
                //一番右のピースを指しているか、ピースが置いなければそれ以上確認しない
                if (x + i == 7 || bord[x + i, y].color == 0)
                {
                    i = 0;
                    break;
                }

                i++;
            }

            Debug.Log(i);

            //bord[x + i, y] が真右方向にある一番近い同じ色のピースになる
            while (i > 1)
            {
                i--;
                bord[x + i, y].TurnPiece();
            }
        }

        //左バージョン
        if (x > 1)
        {
            // 1. 隣のピースから順にピースの色を確認する（色が異なれば）
            int i = 1;
            while (bord[x - i, y].color != bord[x, y].color)
            {
                //一番左のピースを指しているか、ピースが置いなければそれ以上確認しない
                if (x - i == 0 || bord[x - i, y].color == 0)
                {
                    i = 0;
                    break;
                }

                i++;
            }

            Debug.Log(i);

            //bord[x - i, y] が真左方向にある一番近い同じ色のピースになる
            while (i > 1)
            {
                i--;
                bord[x - i, y].TurnPiece();
            }
        }
    }
}
