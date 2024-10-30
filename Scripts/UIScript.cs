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
    /// ��������ľ�̬ʵ���Ա㱻���������
    /// </summary>
    void Awake()
    {
        uiscriptInstance = this;
    }
    public Text stepText;
    public Text scoreText;

    /// <summary>
    /// ��ʼ��Score��Step�ı�
    /// </summary>
    void Start()
    {
        UpdateScore();
        UpdateStep();
    }

    /// <summary>
    /// ����UI��Stepֵ
    /// </summary>
    public void UpdateStep()
    {
        stepText.text = steps.ToString();
    }

    /// <summary>
    /// ����UI��Scoreֵ
    /// </summary>
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

}
