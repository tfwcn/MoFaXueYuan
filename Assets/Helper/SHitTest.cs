using UnityEngine;
using System.Collections;

public class SHitTest : MonoBehaviour
{
    public delegate void DownEventHandler(RaycastHit hit);
    public delegate void HoverEventHandler(RaycastHit hit);
    public delegate void UpEventHandler(RaycastHit hit);
    public delegate void Down2DEventHandler(RaycastHit2D hit);
    public delegate void Hover2DEventHandler(RaycastHit2D hit);
    public delegate void Up2DEventHandler(RaycastHit2D hit);

    public event DownEventHandler DownEvent;
    public event HoverEventHandler HoverEvent;
    public event UpEventHandler UpEvent;
    public event Down2DEventHandler Down2DEvent;
    public event Hover2DEventHandler Hover2DEvent;
    public event Up2DEventHandler Up2DEvent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //2D优先判断
        if (Down2DEvent != null || Hover2DEvent != null || Up2DEvent != null)
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (Down2DEvent != null && hit.transform != null && Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.transform.name);
                Down2DEvent(hit);
                return;
            }
            else if (Up2DEvent != null && hit.transform != null && Input.GetMouseButtonUp(0))
            {
                Debug.Log(hit.transform.name);
                Up2DEvent(hit);
                return;
            }
            else
            {
                if (Hover2DEvent != null)
                {
                    if (hit.transform != null)
                    {
                        Hover2DEvent(hit);
                        return;
                    }
                }
            }
        }
        //3D
        if (DownEvent != null || HoverEvent != null || UpEvent != null)
        {
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                if (DownEvent != null)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.name);
                        DownEvent(hit);
                        return;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (UpEvent != null)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.name);
                        UpEvent(hit);
                        return;
                    }
                }
            }
            else
            {
                if (HoverEvent != null)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        HoverEvent(hit);
                        return;
                    }
                }
            }
        }
    }
}
