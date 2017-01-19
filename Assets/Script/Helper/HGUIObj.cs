using UnityEngine;
using System.Collections;

public class HGUIObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.pixelOffset = Camera.main.WorldToScreenPoint (this.transform.parent.transform.localPosition).ToVector2();
	}
}
