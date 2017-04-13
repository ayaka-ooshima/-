using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectScaleEvent : TweenEventBase
{
	[SerializeField]
	private Vector3 _initScale;
	[SerializeField]
	private Vector3 _targetScale;

	public override void Initialize ()
	{
	}

	protected override Tween OnExecuteTween ()
	{
		return	gameObject.transform.DOScale (_targetScale, _duration);
	}
}
