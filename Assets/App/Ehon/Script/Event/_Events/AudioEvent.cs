using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioEvent : EventBase
{
    [SerializeField]
    private AudioSource _audioSource;

    /// <summary>
    /// 初期化の関数
    /// </summary>
    public override void Initialize()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Raises the execute event.
    /// </summary>
    protected override void OnExecute()
    {
        _audioSource.Play();
    }

    /// <summary>
    /// Raises the complete event.
    /// </summary>
    protected override void OnComplete()
    {
        _audioSource.Stop();
    }
}
