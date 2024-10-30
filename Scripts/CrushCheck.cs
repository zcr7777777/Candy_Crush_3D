using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCheck : MonoBehaviour
{
    public static CrushCheck crushCheckInstance;

    /// <summary>
    /// 创建类的实例以便被其他类调用
    /// </summary>
    private void Awake()
    {
        crushCheckInstance = this;
    }

    /// <summary>
    /// 所有消除的检测调用本方法
    /// </summary>
    /// <returns>消除的数量</returns>
    public int MainCheck()
    {
        int crushCounter=0;
        crushCounter += CheckTCol();
        crushCounter += CheckTRow();
        crushCounter += CheckL();
        crushCounter += CheckRow5();
        crushCounter += CheckCol5();
        crushCounter += CheckRow4();
        crushCounter += CheckCol4();
        crushCounter += CheckRow3();
        crushCounter += CheckCol3();
        DestroyCube();
        return crushCounter;
    }

    /// <summary>
    /// 检测纵向T型的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckTCol()
    {
        int subCounter = 0;
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Generate.cubeMap[i + 2, j]== Generate.cubeMap[i + 2, j + 1]&& Generate.cubeMap[i + 2, j + 1]== Generate.cubeMap[i + 2, j + 2]&& Generate.cubeMap[i + 2, j + 2]== Generate.cubeMap[i + 2, j + 3]&& Generate.cubeMap[i + 2, j + 3]== Generate.cubeMap[i + 2, j + 4]&& Generate.cubeMap[i + 2, j + 4]== Generate.cubeMap[i, j + 2]&& Generate.cubeMap[i, j + 2]== Generate.cubeMap[i + 1, j + 2]&& Generate.cubeMap[i + 1, j + 2]!=0)
                {
                    Generate.cubeMap[i+2, j] = 0;
                    Generate.cubeMap[i + 2, j+1] = 0;
                    Generate.cubeMap[i + 2, j+2] = 0;
                    Generate.cubeMap[i + 2, j+3] = 0;
                    Generate.cubeMap[i + 2, j+4] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i + 1, j + 2] = 0;
                    subCounter += 7;
                }
                if (Generate.cubeMap[i, j]== Generate.cubeMap[i, j + 1]&& Generate.cubeMap[i, j + 1]== Generate.cubeMap[i, j + 2]&& Generate.cubeMap[i, j + 2]== Generate.cubeMap[i, j + 3]&& Generate.cubeMap[i, j + 3]== Generate.cubeMap[i, j + 4]&& Generate.cubeMap[i, j + 4]== Generate.cubeMap[i + 1, j + 2]&& Generate.cubeMap[i + 1, j + 2]== Generate.cubeMap[i + 2, j + 2]&& Generate.cubeMap[i + 2, j + 2]!=0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j + 1] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i, j + 3] = 0;
                    Generate.cubeMap[i, j + 4] = 0;
                    Generate.cubeMap[i+1, j + 2] = 0;
                    Generate.cubeMap[i+2, j + 2] = 0;
                    subCounter += 7;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测横向T型的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckTRow()
    {
        int subCounter = 0;
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j] && Generate.cubeMap[i + 1, j] == Generate.cubeMap[i + 2, j] && Generate.cubeMap[i+2, j] == Generate.cubeMap[i+3, j] && Generate.cubeMap[i+3, j] == Generate.cubeMap[i+4, j] && Generate.cubeMap[i + 2, j] == Generate.cubeMap[i + 2, j+1] && Generate.cubeMap[i + 2, j] == Generate.cubeMap[i + 2, j+2] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i+1, j] = 0;
                    Generate.cubeMap[i+2, j] = 0;
                    Generate.cubeMap[i + 3, j] = 0;
                    Generate.cubeMap[i + 4, j] = 0;
                    Generate.cubeMap[i + 2, j+1] = 0;
                    Generate.cubeMap[i + 2, j+2] = 0;
                    subCounter += 7;
                }
                if (Generate.cubeMap[i + 2, j]== Generate.cubeMap[i + 2, j + 1] && Generate.cubeMap[i + 2, j + 1]== Generate.cubeMap[i + 2, j + 2]&& Generate.cubeMap[i + 2, j + 2]== Generate.cubeMap[i, j + 2]&& Generate.cubeMap[i, j + 2]== Generate.cubeMap[i + 1, j + 2]&& Generate.cubeMap[i + 1, j + 2]== Generate.cubeMap[i + 3, j + 2]&& Generate.cubeMap[i + 3, j + 2]== Generate.cubeMap[i + 4, j + 2]&& Generate.cubeMap[i + 4, j + 2]!=0)
                {
                    Generate.cubeMap[i+2,j] = 0;
                    Generate.cubeMap[i+2,j+1] = 0;
                    Generate.cubeMap[i+2,j+2] = 0;
                    Generate.cubeMap[i,j+2] = 0;
                    Generate.cubeMap[i+1,j+2] = 0;
                    Generate.cubeMap[i+3,j+2] = 0;
                    Generate.cubeMap[i+4,j+2] = 0;
                    subCounter += 7;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测L型的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckL()
    {
        int subCounter = 0;
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j] && Generate.cubeMap[i + 1, j] == Generate.cubeMap[i + 2, j] && Generate.cubeMap[i, j] == Generate.cubeMap[i, j + 1] && Generate.cubeMap[i, j + 1] == Generate.cubeMap[i, j + 2] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j + 1] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i + 1, j] = 0;
                    Generate.cubeMap[i + 2, j] = 0;
                    subCounter += 5;
                }
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j] && Generate.cubeMap[i + 1, j] == Generate.cubeMap[i + 2, j] && Generate.cubeMap[i, j] == Generate.cubeMap[i+2, j + 1] && Generate.cubeMap[i+2, j + 1] == Generate.cubeMap[i+2, j + 2] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i+2, j + 1] = 0;
                    Generate.cubeMap[i+2, j + 2] = 0;
                    Generate.cubeMap[i + 1, j] = 0;
                    Generate.cubeMap[i + 2, j] = 0;
                    subCounter += 5;
                }
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j+2] && Generate.cubeMap[i + 1, j+2] == Generate.cubeMap[i + 2, j+2] && Generate.cubeMap[i, j] == Generate.cubeMap[i, j + 1] && Generate.cubeMap[i, j + 1] == Generate.cubeMap[i, j + 2] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j + 1] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i + 1, j+2] = 0;
                    Generate.cubeMap[i + 2, j+2] = 0;
                    subCounter += 5;
                }
                if (Generate.cubeMap[i, j+2] == Generate.cubeMap[i + 1, j+2] && Generate.cubeMap[i + 1, j+2] == Generate.cubeMap[i + 2, j+2] && Generate.cubeMap[i+2, j+2] == Generate.cubeMap[i+2, j + 1] && Generate.cubeMap[i+2, j + 1] == Generate.cubeMap[i+2, j] && Generate.cubeMap[i+2, j+2] != 0)
                {
                    Generate.cubeMap[i+2, j+2] = 0;
                    Generate.cubeMap[i+2, j + 1] = 0;
                    Generate.cubeMap[i+2, j] = 0;
                    Generate.cubeMap[i + 1, j+2] = 0;
                    Generate.cubeMap[i, j+2] = 0;
                    subCounter += 5;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测横向五连消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckRow5()
    {
        int subCounter = 0;
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j] && Generate.cubeMap[i + 1, j] == Generate.cubeMap[i + 2, j] && Generate.cubeMap[i + 2, j] == Generate.cubeMap[i + 3, j] && Generate.cubeMap[i + 3, j] == Generate.cubeMap[i + 4, j] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i + 1, j] = 0;
                    Generate.cubeMap[i + 2, j] = 0;
                    Generate.cubeMap[i + 3, j] = 0;
                    Generate.cubeMap[i + 4, j] = 0;
                    subCounter += 5;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测纵向五连的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckCol5()
    {
        int subCounter = 0;
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i, j + 1] && Generate.cubeMap[i, j + 1] == Generate.cubeMap[i, j + 2] && Generate.cubeMap[i, j + 2] == Generate.cubeMap[i, j + 3] && Generate.cubeMap[i, j + 3] == Generate.cubeMap[i, j + 4] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j + 1] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i, j + 3] = 0;
                    Generate.cubeMap[i, j + 4] = 0;
                    subCounter += 5;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测横向四连消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckRow4()
    {
        int subCounter = 0;
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i + 1, j] && Generate.cubeMap[i + 1, j] == Generate.cubeMap[i + 2, j] && Generate.cubeMap[i + 2, j] == Generate.cubeMap[i + 3, j] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i + 1, j] = 0;
                    Generate.cubeMap[i + 2, j] = 0;
                    Generate.cubeMap[i + 3, j] = 0;
                    subCounter += 4;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测纵向四连的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckCol4()
    {
        int subCounter = 0;
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i, j + 1] && Generate.cubeMap[i, j + 1] == Generate.cubeMap[i, j + 2] && Generate.cubeMap[i, j + 2] == Generate.cubeMap[i, j + 3] && Generate.cubeMap[i, j] != 0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j + 1] = 0;
                    Generate.cubeMap[i, j + 2] = 0;
                    Generate.cubeMap[i, j + 3] = 0;
                    subCounter += 4;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测横向三连消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckRow3()
    {
        int subCounter=0;
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(Generate.cubeMap[i, j]==Generate.cubeMap[i+1, j]&&Generate.cubeMap[i+1, j]==Generate.cubeMap[i+2, j]&& Generate.cubeMap[i, j]!=0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i+1, j] = 0;
                    Generate.cubeMap[i+2, j] = 0;
                    subCounter += 3;
                }
            }
        }
        return subCounter;
    }

    /// <summary>
    /// 检测纵向三连的消除
    /// </summary>
    /// <returns>消除的数量</returns>
    private int CheckCol3()
    {
        int subCounter=0;
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Generate.cubeMap[i, j] == Generate.cubeMap[i, j+1] && Generate.cubeMap[i, j+1] == Generate.cubeMap[i, j+2]&& Generate.cubeMap[i, j]!=0)
                {
                    Generate.cubeMap[i, j] = 0;
                    Generate.cubeMap[i, j+1] = 0;
                    Generate.cubeMap[i, j+2] = 0;
                    subCounter += 3;
                }
            }
        }
        return subCounter ;
    }

    /// <summary>
    /// 销毁已经被消除的物体
    /// </summary>
    private void DestroyCube()
    {
        for(int i = 0; i < 18; i++)
        {
            for( int j = 0;j < 10; j++)
            {
                if(Generate.cubeMap[i, j] == 0)
                {
                    for(int k = 0; k < 5; k++)
                    {
                        if (GameObject.Find(k+":"+i+","+j) != null)
                        {
                            GameObject.Destroy(GameObject.Find(k + ":" + i + "," + j));
                            Generate.cubeName[i, j] = "";
                        }
                    }
                }
            }
        }
    }
}
