using UnityEngine;
using System.Collections;

public class SText : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        //float x = Camera.main.WorldToScreenPoint(transform.position).x / Screen.width;
        //float y = Camera.main.WorldToScreenPoint(transform.position).y / Screen.height;
        //this.transform.position = new Vector3(x, y, this.transform.position.z + this.transform.parent.position.z);
        //guiText.text = "测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容";
    }
	
	// Update is called once per frame
    void Update()
    {

	}

    void OnGUI()
    {
        float x = Camera.main.WorldToScreenPoint(transform.position).x;
        float y = Camera.main.WorldToScreenPoint(transform.position).y;
        GUILayout.Label("测试内容测试内容测试内容测试内容测试内容测试内容测试内容测试内容");
    }
}
