using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Button))]
public class TitleSceneStart : UIBehaviour {

    protected override void Start()
    {
        base.Start();

        //
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Use this for initialization
    void OnClick () {
        //
        SceneManager.LoadScene("EhonSerect");
	}
	
	
}
