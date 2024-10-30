using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{
    public static GameObject moveFirst=null;
    public static GameObject moveLast=null;
    private static bool moveBack=false;

    /// <summary>
    /// 尝试移动，如果第二个点击的块紧贴第一个则调用realmove方法，否则设置为第一个
    /// </summary>
    /// <param name="secondClick">第二个点击的块</param>
    public static void TryMove(GameObject secondClick)
    {
        float x = secondClick.transform.position.x;
        float y = secondClick.transform.position.y;
        SelectCover.selectCoverInstance.ShowCover(x, y);
        if ((secondClick.transform.position.x==moveFirst.transform.position.x+1&& secondClick.transform.position.y == moveFirst.transform.position.y) || (secondClick.transform.position.x == moveFirst.transform.position.x -1&& secondClick.transform.position.y == moveFirst.transform.position.y) || (secondClick.transform.position.y == moveFirst.transform.position.y + 1&& secondClick.transform.position.x == moveFirst.transform.position.x) || (secondClick.transform.position.y == moveFirst.transform.position.y - 1&& secondClick.transform.position.x == moveFirst.transform.position.x))
        {
            SelectCover.selectCoverInstance.SetColor(new Color(0, 255, 0, 75));
            moveLast = secondClick;
            RealMove();
        }
        else
        {
            moveFirst = secondClick;
        }
    }

    /// <summary>
    /// 块的移动操作，如果移动后不能消除则再移动一次
    /// </summary>
    public static void RealMove()
    {
        int moveFirstX=0, moveFirstY = 0, moveLastX=0, moveLastY=0,cubeMapTmp;
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (moveFirst.name == Generate.cubeName[i, j])
                {
                    moveFirstX = i;
                    moveFirstY=j;
                }
                if(moveLast.name == Generate.cubeName[i, j])
                {
                    moveLastX=i;
                    moveLastY=j;
                }
            }
        }
        cubeMapTmp = Generate.cubeMap[moveFirstX, moveFirstY];
        Generate.cubeMap[moveFirstX, moveFirstY]= Generate.cubeMap[moveLastX, moveLastY];
        Generate.cubeMap[moveLastX, moveLastY] = cubeMapTmp;
        Vector3 tempPos = moveFirst.transform.position;
        string colorFirst = moveFirst.name[..1];
        string posFirst = moveFirst.name[1..];
        string colorLast = moveLast.name[..1];
        string posLast = moveLast.name[1..];
        moveLast.name = colorLast + posFirst;
        moveFirst.name = colorFirst + posLast;
        moveFirst.transform.position = moveLast.transform.position;
        moveLast.transform.position= tempPos;
        Generate.cubeName[moveFirstX,moveFirstY]=moveLast.name;
        Generate.cubeName[moveLastX, moveLastY] = moveFirst.name;
        if (moveBack == false)
        {
            if (colorFirst != colorLast)
            {
                UIScript.steps++;
                UIScript.uiscriptInstance.UpdateStep();
                int crushCounter = CrushCheck.crushCheckInstance.MainCheck();
                if (crushCounter == 0)
                {
                    moveBack = true;
                    SelectCover.selectCoverInstance.ShowCover(moveFirst.transform.position.x, moveLast.transform.position.y);
                    SelectCover.selectCoverInstance.SetColor(new Color(0, 0, 0, 255));
                    RealMove();
                }
                else
                {
                    UIScript.score += crushCounter;
                    UIScript.uiscriptInstance.UpdateScore();
                    MoveDown();
                    moveFirst = null;
                    moveLast = null;
                }
            }
        }
        else
        {
            moveBack=false;
            if (colorFirst != colorLast)
            {
                UIScript.steps--;
                UIScript.uiscriptInstance.UpdateStep();
                moveFirst = null;
                moveLast = null;
            }
        }
        
    }

    /// <summary>
    /// 控制块下落
    /// </summary>
    private static void MoveDown()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                for (int k = 0; k < 9; k++)
                {
                    if (Generate.cubeMap[j, k + 1] == 0 && Generate.cubeMap[j,k]!=0)
                    {
                        MoveToEmpty(j,k);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 把单个块移动到下一个空白位置
    /// </summary>
    /// <param name="x">移动块的x坐标</param>
    /// <param name="y">移动块的y坐标</param>
    private static void MoveToEmpty(int x,int y)
    {
        Generate.cubeMap[x, y + 1] = Generate.cubeMap[x, y];
        Generate.cubeMap[x, y] = 0;
        Generate.cubeName[x, y + 1] = Generate.cubeName[x, y][..1] + ":" + x + "," + (y + 1);

        //start Debug
        Debug.Log(Generate.cubeName[x, y][..1] + ":" + x + "," + (y + 1));
        //end debug

        GameObject moveCube = GameObject.Find(Generate.cubeName[x,y]);
        Generate.cubeName[x, y] = "";
        moveCube.transform.position = new Vector3(moveCube.transform.position.x, moveCube.transform.position.y-1, moveCube.transform.position.z);
        moveCube.name= Generate.cubeName[x, y+1];
    }
}
