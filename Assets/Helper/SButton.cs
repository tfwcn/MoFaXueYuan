using UnityEngine;
using System.Collections;

public class SButton : MonoBehaviour
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
        SGlobal.XSHitTest.DownEvent += new SHitTest.DownEventHandler(XSHitTest_DownEvent);
        SGlobal.XSHitTest.HoverEvent += new SHitTest.HoverEventHandler(XSHitTest_HoverEvent);
        SGlobal.XSHitTest.UpEvent += new SHitTest.UpEventHandler(XSHitTest_UpEvent);
    }

    void XSHitTest_HoverEvent(RaycastHit hit)
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

    void XSHitTest_DownEvent(RaycastHit hit)
    {
        if (hit.transform == this.transform)
        {
            downObj.SetActive(true);
            hoverObj.SetActive(false);
            upObj.SetActive(false);
            isDown = true;
        }
    }

    void XSHitTest_UpEvent(RaycastHit hit)
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
