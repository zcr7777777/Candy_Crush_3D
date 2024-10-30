using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCheck : MonoBehaviour
{
    public static CrushCheck crushCheckInstance;

    /// <summary>
    /// �������ʵ���Ա㱻���������
    /// </summary>
    private void Awake()
    {
        crushCheckInstance = this;
    }

    /// <summary>
    /// ���������ļ����ñ�����
    /// </summary>
    /// <returns>����������</returns>
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
    /// �������T�͵�����
    /// </summary>
    /// <returns>����������</returns>
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
    /// ������T�͵�����
    /// </summary>
    /// <returns>����������</returns>
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
    /// ���L�͵�����
    /// </summary>
    /// <returns>����������</returns>
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
    /// ��������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// �����������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// ��������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// �����������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// ��������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// �����������������
    /// </summary>
    /// <returns>����������</returns>
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
    /// �����Ѿ�������������
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
