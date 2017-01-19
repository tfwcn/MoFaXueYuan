using UnityEngine;
using System.Collections;

public class SGlobal: MonoBehaviour {
    public static SGlobal ThisGlobal;
	//碰撞检测
    public static SHitTest XSHitTest { get; private set; }
    public Color 金;
    public Color 木;
    public Color 水;
    public Color 火;
    public Color 土;

	//在Start前，初始化
	void Awake () {
        ThisGlobal = this;
        XSHitTest =this.gameObject.AddComponent<SHitTest>();
	}

	//初始化
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {

	}
}
