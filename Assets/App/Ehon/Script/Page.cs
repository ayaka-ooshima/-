using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {
    [SerializeField]
    private int pageNum;

    /// <summary>
    /// 
    /// </summary>
    public void Initialize(int pageNum)
    {
        //
        this.pageNum = pageNum;
    }
    /// <summary>
    /// 
    /// </summary>
    public void OnScreenTap()
    {
        Debug.Log("現在のページは" + pageNum);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
