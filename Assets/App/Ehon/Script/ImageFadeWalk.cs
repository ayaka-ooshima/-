using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFadeWalk : EventBase {
    [SerializeField]
    private Image _image;
    [SerializeField]
    private float _fadeWalk;
    //
    private Animator myAnimator;
    //
    private Rigidbody myRigidbody;
    //
    private float _DOFadeWalk = 20f;

    /// <summary>
    /// 
    /// </summary>
    public override void Initialize()
    {
        _image.DOFadeWalk(-4f, 0f);
    }

    /// <summary>
    /// 
    /// </summary>
    public override void ExecuteAction()
    {
        _image.DOFadeWalk(-2f, _fadeWalk);
    }
	// Use this for initialization
	void Start () {
        //
        this.myAnimator = GetComponent<Animator>();
        //
        this.myAnimator.SetFloat("Walk", 1);
        //
        this.myRigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //
        this.myRigidbody.AddForce(this.transform._fadeWalk * this._DOFadeWalk);
	}
}
