using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ � gameObject(����� ��'����) ��� ������
    public List<GameObject> organisms;

    public int spawnNumber = 10;

    public float diameter = 5f;

    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // ������ ���� ���� �� ��� ��, ���� ����� "i"
        // ������ �� ����� "SpawnNumber"
        // "i" ���������� �� 1 ����� �������� �����
        for (int i = 0; i < spawnNumber; i++)
        {
            x_Pos = Random.Range(0f, diameter);
            z_Pos = Random.Range(0f, diameter);
        }
    }
}
