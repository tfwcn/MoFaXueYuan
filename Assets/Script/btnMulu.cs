using UnityEngine;
using System.Collections;

public class btnMulu : MonoBehaviour
{
    GameObject obj;
    GameObject objSelect;
    // Use this for initialization
    void Start()
    {
        obj = this.transform.FindChild("mulu_sub").gameObject;
        obj.SetActive(false);
        objSelect = this.transform.FindChild("select").gameObject;
        SGlobal.XSHitTest.Down2DEvent += new SHitTest.Down2DEventHandler(XSHitTest_Down2DEvent);
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest_Up2DEvent);
    }

    void XSHitTest_Down2DEvent(RaycastHit2D hit)
    {
        if (hit.transform.name == this.transform.name)
        {
            objSelect.SetActive(true);
        }
    }

    void XSHitTest_Up2DEvent(RaycastHit2D hit)
    {
        if (hit.transform.name == this.transform.name)
        {
            objSelect.SetActive(false);
            obj.SetActive(!obj.activeInHierarchy);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
