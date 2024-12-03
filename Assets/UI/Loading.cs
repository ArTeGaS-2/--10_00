using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // ��������� ��� ������ ������ ������������
    public GameObject loadingScreen;

    // ��������� �� ������
    public GameObject dot_1, dot_2, dot_3;

    private void Start()
    {
        StartCoroutine(AnimateDots());
    }

    private IEnumerator AnimateDots()
    {
        Time.timeScale = 0f; // ��������� ��� � ��

        for (int i = 0; i < 3; i++)
        {
            // �������� ������ � 2 ����
            dot_1.transform.localScale = new Vector2(2f, 2f);
            // ��������� ��������� �������� �� ��� (� ��������)
            yield return new WaitForSecondsRealtime(0.1f);
            // ��������� ���������� �����
            dot_1.transform.localScale = new Vector2(1f, 1f);

            // �������� ������ � 2 ����
            dot_2.transform.localScale = new Vector2(2f, 2f);
            // ��������� ��������� �������� �� ��� (� ��������)
            yield return new WaitForSecondsRealtime(0.1f);
            // ��������� ���������� �����
            dot_2.transform.localScale = new Vector2(1f, 1f);

            // �������� ������ � 2 ����
            dot_3.transform.localScale = new Vector2(2f, 2f);
            // ��������� ��������� �������� �� ��� (� ��������)
            yield return new WaitForSecondsRealtime(0.1f);
            // ��������� ���������� �����
            dot_3.transform.localScale = new Vector2(1f, 1f);
        }
        loadingScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
