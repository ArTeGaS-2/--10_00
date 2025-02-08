using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI text; // ��������� �� ��'��� ������
    public int scoreCounter = 0; // ����� ���������

    private void Start()
    {
        Instance = this;
        text.text = "ǳ�����: 0"; // ���������� ������ �������� ������
    }
    public void AddScore()
    {
        scoreCounter++; // ������ 1 �� ���������
        text.text = $"ǳ�����: {scoreCounter}"; // ��������� ����� ��������
    }

}
