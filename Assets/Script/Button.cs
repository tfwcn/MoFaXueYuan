using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        SpriteRenderer sr = this.transform.GetChild(0).renderer as SpriteRenderer;
        sr.color = new Color(255, 0, 0);
    }

    void OnMouseUp()
    {
        SpriteRenderer sr = this.transform.GetChild(0).renderer as SpriteRenderer;
        sr.color = new Color(0, 0, 255);
    }
}
