using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformTweenEvent : TweenEventBase
{
	[Header ("ローカル座標系で指定するかどうか")]
	[SerializeField]
	private bool _isLocal = true;
	[SerializeField]
	private Vector3 _targetPosition;
	[SerializeField]
	private Vector3 _targetRotation;
	[SerializeField]
	private Vector3 _targetScale;


	/// <summary>
	/// 初期化の関数
	/// </summary>
	public override void Initialize ()
	{
	}

	/// <summary>
	/// 実行時のTween
	/// </summary>
	protected override DG.Tweening.Tween OnExecuteTween ()
	{
		if (_isLocal) {
			return DOTween.Sequence ()
			.Append (transform.DOLocalMove (_targetPosition, _duration))
			.Join (transform.DOLocalRotate (_targetRotation, _duration))
			.Join (transform.DOScale (_targetScale, _duration));
		} else {
			return DOTween.Sequence ()
			.Append (transform.DOMove (_targetPosition, _duration))
			.Join (transform.DORotate (_targetRotation, _duration))
			.Join (transform.DOScale (_targetScale, _duration));
		}
	}
}
