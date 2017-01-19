using UnityEngine;
using System.Collections;

public class SMask : MonoBehaviour {
    public Texture2D MaskTexture;
	// Use this for initialization
	void Start () {
        renderer.material.SetTexture("_MaskTex", MaskTexture);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
