using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//EventSystemsを用いてクリックの判定を行う
public class PieceClicked : MonoBehaviour, IPointerClickHandler
{
    private PieceInfo _pieceInfo;

    void Awake()
    {
        _pieceInfo = GetComponent<PieceInfo>();
    }

    /// <summary>
    /// クリックされたときに呼ばれる。
    /// ピースの色を変えて、ターンを変更する
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        _pieceInfo.TurnPiece(GameManager.Instance.currentTurn);
        StageManager.Instance.CheckPieces(_pieceInfo.x, _pieceInfo.y);
        GameManager.Instance.TurnChange();
    }


}
