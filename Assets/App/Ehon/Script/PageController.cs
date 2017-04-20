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
	private void Start ()
	{
		//現在のページ数を設定
		_currentPageNumber = 1;
		//ヒエラルキー階層の一番下に移動させる
		_currentPage = _pageList [0];
		//現在のページを設定
		_currentPage.transform.SetAsLastSibling ();
		//全てのページのInitialize関数を呼んであげる
		foreach (Page page in _pageList) {
			//関数を登録
			page.OnEventEndHandler -= OnNextButtonTap;
			page.OnEventEndHandler += OnNextButtonTap;
			//1ページ目なら
			if (page.PageNum == 1) {
				//初期化
				page.Initialize ();
				//アクティブ化ける
				page.gameObject.SetActive (true);
			} else {
				//非アクティブ
				page.gameObject.SetActive (false);
			}
		}
	}

	//====ボタンのイベントを受け取る===//

	/// <summary>
	/// Nextボタンが押されたときに呼ばれる 
	/// </summary>←詳細を教えてくれる機能
	/// 

	public void OnScreenButtonTap ()
	{
		//確認用ログ
		Debug.Log ("PageController が Screen Tap を 検知");
		//現在のページのOnScreenTap を呼ぶ
		_currentPage.OnScreenTap ();
	}

	/// <summary>
	/// Nextボタンが押されたときに呼ばれる
	/// </summary>
	/// <summary>
	/// Nextボタンが押されたときに呼ばれる
	/// </summary>
	public void OnNextButtonTap ()
	{
		if (_pageList.Count == _currentPageNumber) {
			return;
		}
		//前のページを初期化
		_currentPage.Initialize ();
		//前のページを非アクティブにする(追記)
		_currentPage.gameObject.SetActive (false);
		//ページ数を増やす
		_currentPageNumber = Math.Min (_pageList.Count, _currentPageNumber + 1);
		//現在のページを設定
		_currentPage = _pageList [_currentPageNumber - 1];
		//現在のページをアクティブにする(追記)
		_currentPage.gameObject.SetActive (true);
		//次のページの初期化
		_currentPage.Initialize ();
		//ヒエラルキー階層の一番下に来る
		_currentPage.transform.SetAsLastSibling ();
	}

	/// <summary>
	/// Backボタンが押されたときに呼ばれる 
	/// </summary>
	public void OnBackButtonTap ()
	{
		if (_currentPageNumber == 1) {
			return;
		}
		//現在のページを初期化
		_currentPage.Initialize ();
		//前のページを非アクティブにする(追記)
		_currentPage.gameObject.SetActive (false);
		//ページ数を減らす
		_currentPageNumber = Math.Max (0, _currentPageNumber - 1);
		//現在のページを設定
		_currentPage = _pageList [_currentPageNumber - 1];
		//現在のページをアクティブにする(追記)
		_currentPage.gameObject.SetActive (true);
		//次のページの初期化
		_currentPage.Initialize ();
		//ヒエラルキー階層の一番下に来る
		_currentPage.transform.SetAsLastSibling ();
	}
}