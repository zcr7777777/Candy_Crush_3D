using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectCover : MonoBehaviour
{
    public static SelectCover selectCoverInstance;

    /// <summary>
    /// ������ʵ���Ա㱻���������
    /// </summary>
    void Awake()
    {
        selectCoverInstance = this;
    }
    public GameObject coverX;
    public GameObject coverY;
    public Material coverMat;
    GameObject newCoverX;
    GameObject newCoverY;

    /// <summary>
    /// ����cover����ɫ
    /// </summary>
    /// <param name="color">Ҫ���õ���ɫ</param>
    public void SetColor(Color color)
    {
        coverMat.color= color;
    }

    /// <summary>
    /// ��ʾcover��������cover��λ��
    /// </summary>
    /// <param name="x">coverλ�õ�x����</param>
    /// <param name="y">coverλ�õ�y����</param>
    public void ShowCover(float x, float y)
    {
        SetColor(new Color(100, 100, 100, 75));
        newCoverX.SetActive(true);
        newCoverY.SetActive(true);
        newCoverX.transform.position=new Vector3(0,y,-0.5f);
        newCoverY.transform.position =new Vector3(x,0,-0.5f);
        Invoke(nameof(CancelSelect), 0.5f);
    }

    /// <summary>
    /// ȡ��cover����ʾ
    /// </summary>
    public void CancelSelect()
    {
        newCoverX.SetActive(false);
        newCoverY.SetActive(false);
    }
    
    /// <summary>
    /// ʵ����cover
    /// </summary>
    void Start()
    {
        newCoverX = Instantiate(coverX, new Vector3(0, 5.3f, -0.5f), Quaternion.identity);
        newCoverY = Instantiate(coverY, new Vector3(-8.5f, 0, -0.5f), Quaternion.identity);
        CancelSelect();
    }
}
