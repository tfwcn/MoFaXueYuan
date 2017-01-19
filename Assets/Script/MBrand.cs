using UnityEngine;
using System.Collections;

public enum BrandType { 金 = 0, 木 = 1, 水 = 2, 火 = 3, 土 = 4 }
public class MBrand : MonoBehaviour
{
    public BrandType Type = BrandType.金;
    //public Color 金;
    //public Color 木;
    //public Color 水;
    //public Color 火;
    //public Color 土;
    /// <summary>
    /// 是否已经选择
    /// </summary>
    public bool IsSelect = false;
    /// <summary>
    /// 是否已经出牌
    /// </summary>
    public bool IsOut = true;
	private GameObject brandColor;
    // Use this for initialization
    void Start()
    {
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest_Up2DEvent);
        SetType(Type);
    }

    void XSHitTest_Up2DEvent(RaycastHit2D hit)
    {
        if (hit.transform.name == this.transform.name)
        {
            if (this.IsSelect == false)
            {
                this.transform.parent.Translate(0, 0.5f, 0);
                this.IsSelect = true;
            }
            else
            {
                this.transform.parent.Translate(0, -0.5f, 0);
                this.IsSelect = false;
            }
        }
    }

    public void SetType(BrandType Type)
	{
		brandColor = this.transform.FindChild("BrandColor").gameObject;
        this.Type = Type;
        switch (Type)
        {
            case BrandType.金:
                brandColor.renderer.material.SetColor("_Color", SGlobal.ThisGlobal.金);
                break;
            case BrandType.木:
				brandColor.renderer.material.SetColor("_Color", SGlobal.ThisGlobal.木);
                break;
            case BrandType.水:
				brandColor.renderer.material.SetColor("_Color", SGlobal.ThisGlobal.水);
                break;
            case BrandType.火:
				brandColor.renderer.material.SetColor("_Color", SGlobal.ThisGlobal.火);
                break;
            case BrandType.土:
                brandColor.renderer.material.SetColor("_Color", SGlobal.ThisGlobal.土);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //			RaycastHit hit;
        //			if (Physics.Raycast(ray,out hit))
        //            {
        //				Debug.Log(hit.collider.name);
        //            }
        //        }
    }

    //void OnMouseUp()
    //{
    //    Debug.Log(this.name);
    //    if (isSelect)
    //    {
    //        this.transform.Translate(0,-0.5f,0);
    //        isSelect = false;
    //    }
    //    else
    //    {
    //        this.transform.Translate(0, 0.5f, 0);
    //        isSelect = true;
    //    }
    //}

    void PlayEnd()
    {
        Animator animator = this.GetComponent<Animator>();
        animator.SetInteger("state", 0);
    }
}
