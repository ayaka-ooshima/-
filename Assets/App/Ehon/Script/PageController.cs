using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PageController : MonoBehaviour
{
    //2.ページをすべて管理する
    [SerializeField]//インスペクタから設定するための記号
    private List<Page> _pageList;
    //現在のページ数
    [SerializeField]
    private int _currentPageNumber;

    //1.ページを切り替える処理

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        _currentPageNumber = 1;
        //ヒエラルキー階層の一番下い来る
        _pageList[0].transform.SetAsLastSibling();
    }

    //====ボタンのイベントを受け取る===//

    /// <summary>
    /// Nextボタンが押されたときに呼ばれる 
    /// </summary>
    public void OnNextButtonTap()
    {
        //ページ数を増やす
        _currentPageNumber = Math.Min(_pageList.Count - 1, _currentPageNumber + 1);
        //ヒエラルキー階層の一番下に来る
        _pageList[_currentPageNumber].transform.SetAsLastSibling();
    }

    /// <summary>
    /// Backボタンが押されたときに呼ばれる 
    /// </summary>
    public void OnBackButtonTap()
    {
        //ページ数を増やす
        _currentPageNumber = Math.Max(0, _currentPageNumber - 1);
        //ヒエラルキー階層の一番下に来る
        _pageList[_currentPageNumber].transform.SetAsLastSibling();
    }
}
