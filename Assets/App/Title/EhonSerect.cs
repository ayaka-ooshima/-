﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class EhonSerect : UIBehaviour {

    protected override void Start()
    {
        base.Start();

        //
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Use this for initialization
    void OnClick () {
        //
        SceneManager.LoadScene("Ehon");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}