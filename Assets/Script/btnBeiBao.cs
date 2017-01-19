using UnityEngine;
using System.Collections;

public class btnBeiBao : MonoBehaviour {
	GameObject objSelect;
	SMain main;
    private bool isDown = false;
	// Use this for initialization
	void Start () {
		objSelect = this.transform.FindChild ("select").gameObject;
        main = FindObjectOfType(typeof(SMain)) as SMain;
        SGlobal.XSHitTest.Down2DEvent += new SHitTest.Down2DEventHandler(XSHitTest_Down2DEvent);
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest_Up2DEvent);
    }

    void XSHitTest_Down2DEvent(RaycastHit2D hit)
    {
        if (hit.transform == this.transform && hit.transform.name == "btnBag")
        {
            objSelect.SetActive(true);
            isDown = true;
            Application.LoadLevel("Bag");
        }
        else if (hit.transform == this.transform)
        {
            objSelect.SetActive(true);
            main.MsgObj.SetActive(true);
            isDown = true;
        }
    }

    void XSHitTest_Up2DEvent(RaycastHit2D hit)
    {
        if (isDown||hit.transform == this.transform)
        {
            objSelect.SetActive(false);
            isDown = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
