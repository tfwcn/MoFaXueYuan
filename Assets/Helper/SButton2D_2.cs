using UnityEngine;
using System.Collections;

public class SButton2D_2 : MonoBehaviour
{
	public Color UpColor;
	public Color DownColor;
	public Color HoverColor;
    private bool isDown = false;

    // Use this for initialization
    void Start()
	{
		renderer.material.SetColor ("_Color", UpColor);
        SGlobal.XSHitTest.Down2DEvent += new SHitTest.Down2DEventHandler(XSHitTest2D_Down2DEvent);
        SGlobal.XSHitTest.Up2DEvent += new SHitTest.Up2DEventHandler(XSHitTest2D_Up2DEvent);
        SGlobal.XSHitTest.Hover2DEvent += new SHitTest.Hover2DEventHandler(XSHitTest2D_Hover2DEvent);
    }

    void XSHitTest2D_Hover2DEvent(RaycastHit2D hit)
    {
        if (isDown && hit.transform == this.transform)
		{
			renderer.material.SetColor ("_Color", DownColor);
        }
        else if (hit.transform == this.transform)
		{
			renderer.material.SetColor ("_Color", HoverColor);
        }
        else
		{
			renderer.material.SetColor ("_Color", UpColor);
        }
    }

    void XSHitTest2D_Down2DEvent(RaycastHit2D hit)
    {
        if (hit.transform == this.transform)
		{
			renderer.material.SetColor ("_Color", DownColor);
            isDown = true;
        }
    }

    void XSHitTest2D_Up2DEvent(RaycastHit2D hit)
    {
        if (isDown || hit.transform == this.transform)
		{
			renderer.material.SetColor ("_Color", UpColor);
            isDown = false;
        }
    }

    public void SetColor(Color upColor, Color downColor, Color hoverColor)
    {
        UpColor = upColor;
        DownColor = downColor;
        HoverColor = hoverColor;
        renderer.material.SetColor("_Color", UpColor);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
