using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageScaleUpEvent : EventBase
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private float _defaultScale;
    [SerializeField]
    private float _targetScale;
    [SerializeField]
    private float _duration;

    /// <summary>
    /// 初期化の関数
    /// </summary>
    public override void Initialize()
    {
        _image.rectTransform.localScale = Vector3.one * _defaultScale;
    }

    /// <summary>
    /// イベントが実行されるときに呼ばれる
    /// </summary>
    public override void ExecuteAction()
    {
        _image.rectTransform.DOScale(Vector3.one * _targetScale, _duration);
    }
}

