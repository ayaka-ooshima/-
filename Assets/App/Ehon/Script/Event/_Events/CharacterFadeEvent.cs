using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;

/// <summary>
/// キャラクターをフェードさせるイベント 
/// </summary>
public class CharacterFadeEvent : TweenEventBase
{
	//スケルトンアニメーション
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation;

	/// <summary>
	/// 目標フェード値(1ならフェードイン、0ならフェードアウト) 
	/// </summary>
	[Header ("1ならフェードイン、0ならフェードアウト")]
	[SerializeField]
	private float _targetFadeValue;

	/// <summary>
	/// 初期化の関数
	/// </summary>
	public override void Initialize ()
	{
		_skeletonAnimation = GetComponent<SkeletonAnimation> ();
	}

	/// <summary>
	/// 実行時のTween
	/// </summary>
	protected override Tween OnExecuteTween ()
	{
		return DOTween.To (
			() => _skeletonAnimation.skeleton.a,
			a => _skeletonAnimation.skeleton.a = a,
			_targetFadeValue,
			_duration);
	}
}
