using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Sockets;

public class Page : MonoBehaviour
{
	/// <summary>
	/// ページ番号 
	/// </summary>
	[SerializeField]
	private int _pageNum;
    //
    public int PageNum
    {
        get { return _pageNum; }
    }

    /// <summary>
    /// 現在のイベント番号 
    /// </summary>
    [SerializeField]
	private int _currentEventNumber;

	[SerializeField]
	private bool _isEventExecuting;

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
		//イベントナンバーを初期化
		_currentEventNumber = 0;

		foreach (var e in gameObject.GetComponentsInChildren<EventBase>()) {
			if (_eventOrderToEventList.ContainsKey (e.EventOrder) == false) {
				_eventOrderToEventList.Add (e.EventOrder, new List<EventBase> ());
			}
			//add
			_eventOrderToEventList [e.EventOrder].Add (e);
		}
	}

	/// <summary>
	/// スクリーンがタップされた時に呼ばれる 
	/// </summary>
	public void OnScreenTap ()
	{
		//再生中なら
		if (_isEventExecuting && _eventOrderToEventList.ContainsKey (_currentEventNumber)) {
			//全て完了させる
			foreach (var e in _eventOrderToEventList[_currentEventNumber]) {
				e.Complete ();
			}
			//is animating
			_isEventExecuting = false;
			//return
			return;
		}
		//最後までイベントを見たかどうかをチェック
		if (_currentEventNumber == _eventOrderToEventList.Count) {
			//確認用Log
			Debug.Log ("最後までイベントを見終わりました!");
			//登録した関数を呼ぶ
			OnEventEndHandler.Invoke ();
			//この先の処理を呼ばないためにReturn
			return;
		}
		//イベント番号の更新
		_currentEventNumber += 1;
		//確認用Log
		Debug.LogFormat ("ページ{0}のイベント{1}が実行されます", _pageNum, _currentEventNumber);
		//イベントの実行
		foreach (var e in _eventOrderToEventList[_currentEventNumber]) {
			//set true
			_isEventExecuting = true;
			//イベント実行
			e.Execute ();
			//set handler
			e.OnCompleteEventHandler -= AnimationCompeteDetection;
			e.OnCompleteEventHandler += AnimationCompeteDetection;
		}
	}

	/// <summary>
	/// アニメーションの終了判定 
	/// </summary>
	/// <param name="et">Et.</param>
	private void AnimationCompeteDetection (EventBase et)
	{
		foreach (var e in _eventOrderToEventList[_currentEventNumber]) {
			if (e.IsEventExecuting) {
				return;
			}
		}
		_isEventExecuting = false;
	}
}
