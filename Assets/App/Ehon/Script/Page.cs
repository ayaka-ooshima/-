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
	//
	public int PageNum {
		get { return _pageNum; }
	}

	/// <summary>
	/// 現在のイベント番号 
	/// </summary>
	[SerializeField]
	private int _currentEventOrder;

	/// <summary>
	/// イベント実行中かどうか 
	/// </summary>
	[SerializeField]
	private bool _isEventExecuting;

	/// <summary>
	/// イベントの数 
	/// </summary>
	[SerializeField]
	private int _eventCount;

	/// <summary>
	/// The event order to event list.
	/// </summary>
	private Dictionary<int,List<EventBase>> _eventOrderToEventList = new Dictionary<int, List<EventBase>> ();

	/// <summary>
	/// イベントを最後まで見終わった時に呼ぶ関数を登録する用の変数 
	/// </summary>
	public event Action OnEventEndHandler;

	/// <summary>
	/// シーン再生の初期に呼んであげる関数 
	/// </summary>
	public void Initialize ()
	{
		//全てのイベントを完了させる
		CompleteAllEvent ();
		//イベントナンバーを初期化
		_currentEventOrder = 0;
		//イベントリストの初期化
		_eventOrderToEventList.Clear ();
		//イベント実行中かどうかを初期化
		_isEventExecuting = false;
		//EventBaseを継承したコンポーネントを全て取得
		foreach (var e in gameObject.GetComponentsInChildren<EventBase>()) {
			if (_eventOrderToEventList.ContainsKey (e.EventOrder) == false) {
				_eventOrderToEventList.Add (e.EventOrder, new List<EventBase> ());
			}
			//add
			_eventOrderToEventList [e.EventOrder].Add (e);
		}
		//イベント数を設定
		_eventCount = _eventOrderToEventList.Count;
		//最初のイベントを実行
		ExecuteEvents (_currentEventOrder);
	}

	/// <summary>
	/// スクリーンがタップされた時に呼ばれる 
	/// </summary>
	public void OnScreenTap ()
	{
		//再生中なら
		if (_isEventExecuting) {
            
			//log
			Debug.LogFormat ("イベントを強制終了! EventOrder:{0}", _currentEventOrder);
			//全て完了させる
			foreach (var e in _eventOrderToEventList[_currentEventOrder]) {
				e.Complete ();
			}
            
			//return
			return;
		}
		//最後までイベントを見たかどうかをチェック
		if (_currentEventOrder >= _eventCount) {
			//確認用Log
			Debug.Log ("最後までイベントを見終わりました!");
			//登録した関数を呼ぶ
			OnEventEndHandler.Invoke ();
			//この先の処理を呼ばないためにReturn
			return;
		}
		//イベント実行
		ExecuteEvents (_currentEventOrder);
	}

	/// <summary>
	/// 0番目のイベントを実行 
	/// </summary>
	private void ExecuteEvents (int eventOrder)
	{
		//イベンリスト
		List<EventBase> eventList;
		//イベントリストの取得
		if (_eventOrderToEventList.TryGetValue (eventOrder, out eventList) == false) {
			//log
			Debug.LogFormat ("イベントの取得ができません! EventOrder:{0}", _currentEventOrder);
			//イベント番号の更新
			_currentEventOrder += 1;
			//return
			return;
		}
		//確認用Log
		Debug.LogFormat ("ページ{0}のイベント{1}が実行されます", _pageNum, _currentEventOrder);
		//イベントの実行
		foreach (var e in eventList) {
			//set true
			_isEventExecuting = true;
			//イベント実行
			e.Execute ();
			//set handler
			e.OnCompleteEventHandler -= AnimationCompleteDetection;
			e.OnCompleteEventHandler += AnimationCompleteDetection;
		}
	}
    /// <summary>
    /// アニメーションの終了判定 
    /// </summary>
    /// <param name="et">Et.</param>
    private void AnimationCompleteDetection(EventBase et)
    {
        //イベント実行中ではないなら
        if (_isEventExecuting == false)
        {
            //リターン(この先の処理を呼ばない
            return;
        }
        //全て実行終了したかチェック
        foreach (var e in _eventOrderToEventList[et.EventOrder])
        {
            if (e.IsEventExecuting)
            {
                return;
            }
        }
        //イベント実行をfalse
        _isEventExecuting = false;
        //イベント番号の更新
        _currentEventOrder += 1;
    }


	/// <summary>
	/// 全てのイベントを完了させる
	/// </summary>
	private void CompleteAllEvent ()
	{
		foreach (var dic in _eventOrderToEventList) {
			foreach (var e in dic.Value) {
				e.Complete ();
			}
		}
	}

}
