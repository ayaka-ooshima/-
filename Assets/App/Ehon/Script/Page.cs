using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Page : MonoBehaviour
{
    /// <summary>
    /// ページ番号 
    /// </summary>
    [SerializeField]
    private int _pageNum;

    /// <summary>
    /// 現在のイベント番号 
    /// </summary>
    [SerializeField]
    private int _currentEventNumber;

    /// <summary>
    /// イベントコンテナのリスト 
    /// </summary>
    [SerializeField]
    private List<EventContainer> _eventContainerList;

    /// <summary>
    /// イベントを最後まで見終わった時に呼ぶ関数を登録する用の変数 
    /// </summary>
    public event Action OnEventEndHandler;

    /// <summary>
    /// シーン再生の初期に呼んであげる関数 
    /// </summary>
    public void Initialize()
    {
        //イベントナンバーを初期化
        _currentEventNumber = 0;

        //イベントコンテナの初期化
        foreach (EventContainer container in _eventContainerList)
        {
            container.Initialize();
        }
    }

    /// <summary>
    /// スクリーンがタップされた時に呼ばれる 
    /// </summary>
    public void OnScreenTap()
    {
        //最後までイベントを見たかどうかをチェック
        if (_currentEventNumber == _eventContainerList.Count)
        {
            //確認用Log
            Debug.Log("最後までイベントを見終わりました!");
            //登録した関数を呼ぶ
            OnEventEndHandler.Invoke();
            //この先の処理を呼ばないためにReturn
            return;
        }
        //取り出すイベントコンテナのインデックス
        int eventIndex = Math.Min(_currentEventNumber, _eventContainerList.Count - 1);
        //イベント番号の更新
        _currentEventNumber += 1;
        //確認用Log
        Debug.LogFormat("ページ{0}のイベント{1}が実行されます", _pageNum, _currentEventNumber);
        //イベントの実行
        _eventContainerList[eventIndex].ExecuteEvent();
    }
}
