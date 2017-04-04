using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFadeInEvent : EventBase
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private float _fadeTime;

    /// <summary>
    /// 初期化の関数
    /// </summary>
    public override void Initialize()
    {
        _image.DOFade(0f, 0f);
    }

    /// <summary>
    /// イベントが実行されるときに呼ばれる
    /// </summary>
    public override void ExecuteAction()
    {
        _image.DOFade(1f, _fadeTime);
    }
}
