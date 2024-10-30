using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static UIScript uiscriptInstance;
    public static int score=0;
    public static int steps=0;

    /// <summary>
    /// 创建此类的静态实例以便被其他类调用
    /// </summary>
    void Awake()
    {
        uiscriptInstance = this;
    }
    public Text stepText;
    public Text scoreText;

    /// <summary>
    /// 初始化Score和Step文本
    /// </summary>
    void Start()
    {
        UpdateScore();
        UpdateStep();
    }

    /// <summary>
    /// 更新UI的Step值
    /// </summary>
    public void UpdateStep()
    {
        stepText.text = steps.ToString();
    }

    /// <summary>
    /// 更新UI的Score值
    /// </summary>
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// 重置棋盘
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

}
