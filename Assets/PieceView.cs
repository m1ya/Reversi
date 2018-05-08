using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceView : MonoBehaviour
{
    private PieceInfo _pieceInfo;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _pieceInfo = GetComponent<PieceInfo>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 見た目を更新する
    /// </summary>
    public void UpdateView()
    {
        switch (_pieceInfo.color)
        {
            case 0:
                _spriteRenderer.enabled = false;
                break;
            case 1:
                _spriteRenderer.enabled = true;
                _spriteRenderer.color = Color.white;
                break;
            case 2:
                _spriteRenderer.enabled = true;
                _spriteRenderer.color = Color.black;
                break;
        }
    }
}
