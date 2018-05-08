using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singletonというデザインパターンを用いて、簡単にGameManagerにアクセスできるようにする。
    public static GameManager Instance;
    //現在どちらのターンか、1なら白、2なら黒
    public int currentTurn = 1;

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

    /// <summary>
    /// ターンを変更する
    /// </summary>
    public void TurnChange()
    {
        if (currentTurn == 1)
        {
            currentTurn = 2;
        }
        else
        {
            currentTurn = 1;
        }
    }
}
