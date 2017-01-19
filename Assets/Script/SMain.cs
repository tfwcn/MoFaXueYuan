using UnityEngine;
using System.Collections;

public class SMain : MonoBehaviour {
    //string user="";
    //string password="";
	// Use this for initialization
	public GameObject MsgObj;
	public GUIText MsgTextObj;
    void Start()
    {
		//锁定比例
        //Camera.main.aspect = 16 / 9f;
        float x = 0, y = 0, width = 0, height = 0;
        if (Screen.width / Screen.height > 16 / 9f)
        {
            width = Screen.height * (16 / 9f);
            height = Screen.height;
        }
        else
        {
            width = Screen.width;
            height = Screen.width * (9 / 16f);
        }
        x = (Screen.width - width) / 2;
        y = (Screen.height - height) / 2;
        Camera.main.pixelRect = new Rect(x, y, width, height);

		MsgObj=Instantiate (MsgObj) as GameObject;
		MsgTextObj=MsgObj.transform.FindChild ("MsgText").guiText;
	}
	
	// Update is called once per frame
    void Update()
    {
        //MobilePick();
        //MousePick();
	}

    void OnGUI()
    {
        //using (HGUISizeLocker locker = new HGUISizeLocker())
        //{
        //    Rect rect=new Rect(0,0,300,60);
        //    HGUIHelper.PositionCenter(ref rect);
        //    rect.y-=60;
        //    user = GUI.TextField(rect, user);
        //    rect.y += 120;
        //    password = GUI.PasswordField(rect, password, '*');
        //    if (user == "test" && password == "test")
        //    {
        //        Application.LoadLevel("Begin");
        //    }
        //}
    }

    void MobilePick()
    {
        if (Input.touchCount != 1)
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                //Debug.Log(hit.transform.tag);
            }
        }
    }

    void MousePick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                //Debug.Log(hit.transform.tag);
            }
        }
    }
}
