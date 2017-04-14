using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EventBase : MonoBehaviour
{

	[Header ("アニメーションの順番(例：1に設定すると1タップ目のイベントになる)")]
	[SerializeField]
	protected int _eventOrder;

	public int EventOrder {
		get{ return _eventOrder; }
	}

	[Header ("イベントの実行時間")]
	[SerializeField]
	protected float _duration;

	[Header ("イベントの実行の遅延時間")]
	[SerializeField]
	protected float _delay;

	[Header ("イベント実行中かどうか")]
	[SerializeField]
	private bool _isEventExecuting;

	public bool IsEventExecuting {
		get{ return _isEventExecuting; }
	}

	/// <summary>
	/// Occurs when on complete event handler.
	/// </summary>
	public event Action<EventBase> OnCompleteEventHandler;

	/// <summary>
	/// 初期化の関数
	/// </summary>
	public abstract void Initialize ();

	/// <summary>
	/// イベント実行の関数 
	/// </summary>
	public void Execute ()
	{
		StartCoroutine (Execute_ ());
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	protected IEnumerator Execute_ ()
	{
        //set true 
        _isEventExecuting = true;

        //遅延待機
        yield return new WaitForSeconds(_delay);

        OnExecute();

        //実行待機
        yield return new WaitForSeconds(_duration);

        Complete();
    }

    /// <summary>
    /// Raises the execute event.
    /// </summary>
    protected abstract void OnExecute ();

	/// <summary>
	/// Raises the complete event.
	/// </summary>
	protected abstract void OnComplete ();

	/// <summary>
	/// Complete this instance.
	/// </summary>
	public void Complete ()
	{
		//set false
		_isEventExecuting = false;
		//on complete
		OnComplete ();	
		//on complete
		OnCompleteEventHandler.Invoke (this);
	}
}
