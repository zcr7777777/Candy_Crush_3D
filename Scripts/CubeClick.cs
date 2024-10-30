using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeClick : MonoBehaviour,IPointerClickHandler
{
    public GameObject clickCube;
    /// <summary>
    /// 块被点击时尝试移动
    /// </summary>
    /// <param name="eventData">由Unity编辑器提供</param>
    public void OnPointerClick(PointerEventData eventData)
    { 
        if (CubeMove.moveFirst == null)
        {
            float x=clickCube.transform.position.x;
            float y = clickCube.transform.position.y;
            SelectCover.selectCoverInstance.ShowCover(x, y);
            CubeMove.moveFirst = clickCube;
        }
        else
        {
            CubeMove.TryMove(clickCube);
        }

    }
}