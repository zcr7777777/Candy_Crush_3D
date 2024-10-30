using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject GreenCube;
    public GameObject BlueCube;
    public GameObject YellowCube;
    public GameObject PurpleCube;
    public GameObject RedCube;
    public static int[,] cubeMap=new int[18,10];
    public static string[,] cubeName = new string[18, 10];
    /// <summary>
    /// 初始化棋盘，将各个块的位置和名字写入二维数组，如果有可消除的块则重新生成该块
    /// </summary>
    void Start()
    {
        for (int i = 0; i < 18; i++) {
            for (int j = 0; j < 10; j++) { 
                int type=Random.Range(1, 5);
                if (i >= 2)
                {
                    if (cubeMap[i - 1, j] == cubeMap[i - 2, j] && cubeMap[i - 1, j] == type)
                    {
                        type += 1;
                        if(type > 5)
                        {
                            type -= 5;
                        }
                    }
                }
                if (j >= 2) { 
                    if (cubeMap[i, j - 1] == cubeMap[i, j - 2] && cubeMap[i, j - 1] == type) 
                    {
                        type += 1;
                        if (type > 5)
                        {
                            type -= 5;
                        }
                    }
                }
                if (i >= 2)
                {
                    if (cubeMap[i - 1, j] == cubeMap[i - 2, j] && cubeMap[i - 1, j] == type)
                    {
                        type += 1;
                        if (type > 5)
                        {
                            type -= 5;
                        }
                    }
                }
                cubeMap[i,j] = type;
                switch (type) { 
                    case 1:
                        GameObject newRed=Instantiate(RedCube, new Vector3(-8.5f+i, 5.3f-j, 0), Quaternion.identity);
                        newRed.name="1"+":"+i.ToString()+","+j.ToString();
                        cubeName[i,j] = newRed.name;
                        break;
                    case 2:
                        GameObject newYellow = Instantiate(YellowCube, new Vector3(-8.5f + i, 5.3f - j, 0), Quaternion.identity);
                        newYellow.name = "2" + ":" + i.ToString() + "," + j.ToString();
                        cubeName[i, j] = newYellow.name;
                        break;
                    case 3:
                        GameObject newBlue = Instantiate(BlueCube, new Vector3(-8.5f + i, 5.3f - j, 0), Quaternion.identity);
                        newBlue.name = "3" + ":" + i.ToString() + "," + j.ToString();
                        cubeName[i, j] = newBlue.name;
                        break;
                    case 4:
                        GameObject newPurple = Instantiate(PurpleCube, new Vector3(-8.5f + i, 5.3f - j, 0), Quaternion.identity);
                        newPurple.name = "4" + ":" + i.ToString() + "," + j.ToString();
                        cubeName[i, j] = newPurple.name;
                        break;
                    case 5:
                        GameObject newGreen = Instantiate(GreenCube, new Vector3(-8.5f + i, 5.3f - j, 0), Quaternion.identity);
                        newGreen.name = "5" + ":" + i.ToString() + "," + j.ToString();
                        cubeName[i, j] = newGreen.name;
                        break;
                }
            }
        }
    }
}
