using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// DoTweenを使ったイベントはこのクラスを継承する必要があります 
/// </summary>
public abstract class TweenEventBase : EventBase
{
	/// <summary>
	/// アニメーションのタイプ 
	/// </summary>
	[Header ("アニメーションのタイプ")]
	[SerializeField]
	protected Ease _easeType = Ease.Linear;

	/// <summary>
	/// 実行時のTween 
	/// </summary>
	protected Tween _actionTween;

	/// <summary>
	/// 実行するアクション
	/// </summary>
	protected override void OnExecute ()
	{
		_actionTween = OnExecuteTween ().SetEase (_easeType);
	}

	/// <summary>
	/// 実行時のTween 
	/// </summary>
	protected abstract Tween OnExecuteTween ();

	/// <summary>
	/// アニメーション終了時の処理
	/// </summary>
	protected override void OnComplete ()
	{
		_actionTween.Complete ();
	}
}
