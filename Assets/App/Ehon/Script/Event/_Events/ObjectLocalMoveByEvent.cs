using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectLocalMoveByEvent : TweenEventBase
{
	[SerializeField]
	private Vector3 _targetLocalPosition;

	/// <summary>
	/// 初期化関数
	/// </summary>
	public override void Initialize ()
	{
	}

	/// <summary>
	/// 実行時のTween
	/// </summary>
	protected override Tween OnExecuteTween ()
	{
		return gameObject.transform.DOBlendableLocalMoveBy (_targetLocalPosition, _duration);
	}
}