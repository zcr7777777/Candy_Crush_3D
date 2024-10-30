using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeClick : MonoBehaviour,IPointerClickHandler
{
    public GameObject clickCube;
    /// <summary>
    /// �鱻���ʱ�����ƶ�
    /// </summary>
    /// <param name="eventData">��Unity�༭���ṩ</param>
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