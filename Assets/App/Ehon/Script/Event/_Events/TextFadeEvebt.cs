using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFadeEvent : TweenEventBase
{
    [SerializeField]
    private Text _text;

    /// <summary>
    /// 目標時 
    /// </summary>
    [SerializeField]
    private float _targetValue;

    /// <summary>
    /// 初期化の関数
    /// </summary>
    public override void Initialize()
    {
      _text = GetComponent<Text>();
    }

    /// <summary>
    /// イベントが実行されるときに呼ばれる
    /// </summary>
    protected override Tween OnExecuteTween()
    {
        return _text.DOFade(_targetValue, _duration);
    }
}
