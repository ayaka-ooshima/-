using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    /// <summary>
    /// 絵本選択ボタン 
    /// </summary>
    [SerializeField]
    private Button _ehonSelectButton;

    /// <summary>
    /// ページを切り替えるアニメーション
    /// </summary>
    private Tween _pagingAnimation;

    //1.ページを切り替える処理

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        //絵本選択ボタンを非表示
        _ehonSelectButton.gameObject.SetActive(false);
        //現在のページ数を設定
        _currentPageNumber = 1;
        //ヒエラルキー階層の一番下に移動させる
        _currentPage = _pageList[0];
        //現在のページを設定
        _currentPage.transform.SetAsLastSibling();
        //全てのページのInitialize関数を呼んであげる
        foreach (Page page in _pageList)
        {
            //関数を登録
            page.OnEventEndHandler -= OnNextButtonTap;
            page.OnEventEndHandler += OnNextButtonTap;
            //1ページ目なら
            if (page.PageNum == 1)
            {
               
                //アクティブ化
                page.gameObject.SetActive(true);
                //初期化
                page.Initialize();
            }
            else
            {
                //非アクティブ
                page.gameObject.SetActive(false);
            }
        }
    }

    //====ボタンのイベントを受け取る===//

    /// <summary>
    /// Nextボタンが押されたときに呼ばれる 
    /// </summary>←詳細を教えてくれる機能
    /// 

    public void OnScreenButtonTap()
    {
        //確認用ログ
        Debug.Log("PageController が Screen Tap を 検知");
        //現在のページのOnScreenTap を呼ぶ
        _currentPage.OnScreenTap();
    }

    /// <summary>
    /// Nextボタンが押されたときに呼ばれる
    /// </summary>
    /// <summary>
    /// Nextボタンが押されたときに呼ばれる
    /// </summary>
    public void OnNextButtonTap()
    {
        //ページ切り替え中なら
        if (_pagingAnimation != null && _pagingAnimation.IsPlaying())
        {
            return;
        }
        //最初のページなら
        if (_pageList.Count == _currentPageNumber)
        {
            //絵本選択ボタンを表示
            _ehonSelectButton.gameObject.SetActive(true);
            return;
        }
        //ページ数を増やす
        _currentPageNumber = Math.Min(_pageList.Count, _currentPageNumber + 1);
        //次のページ
        Page nextPage = _pageList[_currentPageNumber - 1];
        //次のページを右側にもってくる
        nextPage.transform.localPosition = new Vector3(1920f, 0, 0);
        //次のページをアクティブ
        nextPage.gameObject.SetActive(true);
        //ヒエラルキー階層の一番下に来る
        nextPage.transform.SetAsLastSibling();
        //初期化
        nextPage.Initialize();
        //ページをずらすアニメーション
        _pagingAnimation = DOTween.Sequence()
            .Append(nextPage.transform.DOLocalMoveX(0, 1.0f))
            .Join(_currentPage.transform.DOLocalMoveX(-1920f, 1f))
            .OnComplete(() => {
                //現在のページい設定
                _currentPage = nextPage;
            });
    }

    /// <summary>
    /// Backボタンが押されたときに呼ばれる 
    /// </summary>
    public void OnBackButtonTap()
    {
        //ページ切り替え中なら
        if (_pagingAnimation != null && _pagingAnimation.IsPlaying())
        {
            return;
        }
        if (_currentPageNumber == 1)
        {
            return;
        }
        //ページ数を減らす
        _currentPageNumber = Math.Max(0, _currentPageNumber - 1);
        //前のページ
        Page prevPage = _pageList[_currentPageNumber - 1];
        //前のページを左側にもってくる
        prevPage.transform.localPosition = new Vector3(-1920f, 0, 0);
        //まえのページをアクティブ
        prevPage.gameObject.SetActive(true);
        //ヒエラルキー階層の一番下に来る
        prevPage.transform.SetAsLastSibling();
        //初期化
        prevPage.Initialize();
        //ページをずらすアニメーション
        _pagingAnimation = DOTween.Sequence()
            .Append(prevPage.transform.DOLocalMoveX(0, 1.0f))
            .Join(_currentPage.transform.DOLocalMoveX(1920f, 1f))
            .OnComplete(() => {
                //現在のページい設定
                _currentPage = prevPage;
            });
    }
    /// <summary>
    /// 絵本選択ボタンを押した時に呼ばれる 
    /// </summary>
    public void OnEhonSelectButtonTap()
    {
        SceneManager.LoadScene("EhonSerect");
    }
}