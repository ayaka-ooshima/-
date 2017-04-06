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
   
    /// <summary>
    /// 
    /// </summary>
    public override void Initialize()
    {
        _image.rectTransform.localPosition = new Vector3(this._fadeWalk, -
            4);
            }

    /// <summary>
    /// 
    /// </summary>
    public override void ExecuteAction()
    {
        _image.GetComponent<RectTransform>().DOAnchorPos(new Vector2(50, 100), 3.5f);
    }
	// Use this for initialization
	void Start () {
       		
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
