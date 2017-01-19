using UnityEngine;
using System.Collections;
using System;

public class HGUISizeLocker : MonoBehaviour, IDisposable
{
    Matrix4x4 oldMatrix;
    //默认比例
    public static float m_fScreenWidth = 1920;
    public static float m_fScreenHeight = 1080;
    //世界比例
    float m_fScaleWidth;
    float m_fScaleHeight;
    public HGUISizeLocker()
    {
        m_fScaleWidth = Screen.width / m_fScreenWidth;
        m_fScaleHeight = Screen.height / m_fScreenHeight;
        oldMatrix = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(m_fScaleWidth, m_fScaleHeight, 1));
    }

    ~HGUISizeLocker()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dispose()
    {
        GUI.matrix = oldMatrix;
    }
}
