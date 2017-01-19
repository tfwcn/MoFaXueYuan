﻿using UnityEngine;
using System.Collections;

public class BagAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest_Up2DEvent);
	}

    void XSHitTest_Up2DEvent(RaycastHit2D hit)
    {
        if (hit.transform.name == "btnOK")
        {
            //切换场景到Main   
            Application.LoadLevel("Main");
        }
        else if (hit.transform.name == "btnRetrun")
        {
            //切换场景到Main   
            Application.LoadLevel("Main");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
