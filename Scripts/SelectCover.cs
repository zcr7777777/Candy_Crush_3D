using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectCover : MonoBehaviour
{
    public static SelectCover selectCoverInstance;

    /// <summary>
    /// 创建类实例以便被其他类调用
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
    /// 设置cover的颜色
    /// </summary>
    /// <param name="color">要设置的颜色</param>
    public void SetColor(Color color)
    {
        coverMat.color= color;
    }

    /// <summary>
    /// 显示cover，并设置cover的位置
    /// </summary>
    /// <param name="x">cover位置的x坐标</param>
    /// <param name="y">cover位置的y坐标</param>
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
    /// 取消cover的显示
    /// </summary>
    public void CancelSelect()
    {
        newCoverX.SetActive(false);
        newCoverY.SetActive(false);
    }
    
    /// <summary>
    /// 实例化cover
    /// </summary>
    void Start()
    {
        newCoverX = Instantiate(coverX, new Vector3(0, 5.3f, -0.5f), Quaternion.identity);
        newCoverY = Instantiate(coverY, new Vector3(-8.5f, 0, -0.5f), Quaternion.identity);
        CancelSelect();
    }
}
