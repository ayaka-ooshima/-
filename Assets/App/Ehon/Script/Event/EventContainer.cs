using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イベントを束ねるクラス 
/// </summary>
public class EventContainer : MonoBehaviour
{
    /// <summary>
    /// イベントの順番 
    /// </summary>
    [SerializeField]
    private int _eventOrder;

    /// <summary>
    /// イベントのリスト 
    /// </summary>
    [SerializeField]
    private List<EventBase> _eventList;

    /// <summary>
    /// 初期化の関数 
    /// </summary>
    public void Initialize()
    {
        //イベントの初期化
        foreach (EventBase ev in _eventList)
        {
            ev.Initialize();
        }
    }

    /// <summary>
    /// Executes the event.
    /// </summary>
    public void ExecuteEvent()
    {
        Debug.Log(_eventOrder + "イベントが実行されました");
        //イベントの実行
        foreach (EventBase ev in _eventList)
        {
            ev.ExecuteAction();
        }
    }
}
