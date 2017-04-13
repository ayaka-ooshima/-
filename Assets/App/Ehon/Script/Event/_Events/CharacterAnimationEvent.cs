using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterAnimationEvent :  EventBase
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation;

	/// <summary>
	/// 開始時のアニメーション
	/// </summary>
	[SpineAnimation]
	[SerializeField]
	private string _startAnimationName;

	/// <summary>
	/// 開始時のアニメーションをループさせるかどうか
	/// </summary>
	[SerializeField]
	private bool _isLoopStartAnimation;

	/// <summary>
	/// 終了時のアニメーション
	/// </summary>
	[SpineAnimation]
	[SerializeField]
	private string _endAnimationName;

	/// <summary>
	/// 終了時のアニメーションをループさせるかどうか
	/// </summary>
	[SerializeField]
	private bool _isLoopEndAnimation;


	/// <summary>
	/// 初期化関数
	/// </summary>
	public override void Initialize ()
	{
	}

	/// <summary>
	/// 実行するアクション
	/// </summary>
	protected override void OnExecute ()
	{
		//StartAnimationを実行
		_skeletonAnimation.state.SetAnimation (0, _startAnimationName, _isLoopStartAnimation);
	}

	/// <summary>
	/// アニメーション終了時の処理
	/// </summary>
	protected override void OnComplete ()
	{
		//アニメーションを実行
		_skeletonAnimation.state.SetAnimation (0, _endAnimationName, _isLoopEndAnimation);
	}
}
