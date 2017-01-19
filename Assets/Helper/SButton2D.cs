using UnityEngine;
using System.Collections;

public class SButton2D : MonoBehaviour
{
    private GameObject downObj;
    private GameObject hoverObj;
    private GameObject upObj;
    private bool isDown = false;

    // Use this for initialization
    void Start()
    {
        downObj = this.transform.FindChild("downObj").gameObject;
        hoverObj = this.transform.FindChild("hoverObj").gameObject;
        upObj = this.transform.FindChild("upObj").gameObject;
        SGlobal.XSHitTest.Down2DEvent += new SHitTest.Down2DEventHandler(XSHitTest2D_Down2DEvent);
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest2D_Up2DEvent);
        SGlobal.XSHitTest.Hover2DEvent += new SHitTest.Hover2DEventHandler(XSHitTest2D_Hover2DEvent);
        downObj.SetActive(false);
        hoverObj.SetActive(false);
        upObj.SetActive(true);
    }

    void XSHitTest2D_Hover2DEvent(RaycastHit2D hit)
    {
        if (isDown && hit.transform == this.transform)
        {
            downObj.SetActive(true);
            hoverObj.SetActive(false);
            upObj.SetActive(false);
        }
        else if (hit.transform == this.transform)
        {
            hoverObj.SetActive(true);
            downObj.SetActive(false);
            upObj.SetActive(false);
        }
        else
        {
            downObj.SetActive(false);
            hoverObj.SetActive(false);
            upObj.SetActive(true);
        }
    }

    void XSHitTest2D_Down2DEvent(RaycastHit2D hit)
    {
        if (hit.transform == this.transform)
        {
            downObj.SetActive(true);
            hoverObj.SetActive(false);
            upObj.SetActive(false);
            isDown = true;
        }
    }

    void XSHitTest2D_Up2DEvent(RaycastHit2D hit)
    {
        if (isDown || hit.transform == this.transform)
        {
            downObj.SetActive(false);
            hoverObj.SetActive(false);
            upObj.SetActive(true);
            isDown = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
