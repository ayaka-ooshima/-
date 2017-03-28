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
    //現在のページ
    [SerializeField]
    private Page _currentPage;

    //1.ページを切り替える処理

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        _currentPageNumber = 1;
        //ヒエラルキー階層の一番下い来る
        _currentPage = _pageList[0];
        //現在のページを設定
        _currentPage.transform.SetAsLastSibling();
        //
        for (int i = 0; i < _pageList.Count; i++)
        {
            Page page = _pageList[i];
            page.Initialize(i + 1);
        }
    }

    //====ボタンのイベントを受け取る===//

    /// <summary>
    /// Nextボタンが押されたときに呼ばれる 
    /// </summary>←詳細を教えてくれる機能
    /// 

    public void OnScreenButtonTap()
    {
        Debug.Log("Screen Tap");
        _currentPage.OnScreenTap();
    }

    /// <summary>
    /// Nextボタンが押されたときに呼ばれる
    /// </summary>
    public void OnNextButtonTap()
    {
        //ページ数を増やす
        _currentPageNumber = Math.Min(_pageList.Count - 1, _currentPageNumber + 1);
        //現在のページを設定
        _currentPage = _pageList[_currentPageNumber];
        //ヒエラルキー階層の一番下に来る
        _currentPage.transform.SetAsLastSibling();
    }

    /// <summary>
    /// Backボタンが押されたときに呼ばれる 
    /// </summary>
    public void OnBackButtonTap()
    {
        //ページ数を増やす
        _currentPageNumber = Math.Max(0, _currentPageNumber - 1);
        //現在のページを設定
        _currentPage = _pageList[_currentPageNumber];
        //ヒエラルキー階層の一番下に来る
        _currentPage.transform.SetAsLastSibling();
    }
}
