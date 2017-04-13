using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFadeEvent : TweenEventBase
{
	[SerializeField]
	private Image _image;

	/// <summary>
	/// 目標時 
	/// </summary>
	[SerializeField]
	private float _targetValue;

	/// <summary>
	/// 初期化の関数
	/// </summary>
	public override void Initialize ()
	{
		_image = GetComponent<Image> ();
	}

	/// <summary>
	/// イベントが実行されるときに呼ばれる
	/// </summary>
	protected override Tween OnExecuteTween ()
	{
		return _image.DOFade (_targetValue, _duration);
	}
}
