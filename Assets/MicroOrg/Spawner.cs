using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ � gameObject(����� ��'����) ��� ������
    public List<GameObject> organisms;

    // ����������� ����� �������� ��'����
    public int spawnNumber = 10;

    // ĳ�����, � ����� ��������� �����
    public float diameter = 5f;

    // ���������, �� ��������� ���� ������� ������
    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // ������ ���� ���� �� ��� ��, ���� ����� "i"
        // ������ �� ����� "SpawnNumber"
        // "i" ���������� �� 1 ����� �������� �����
        for (int i = 0; i < spawnNumber; i++)
        {
            // ���� �������� ���������
            x_Pos = Random.Range(-diameter, diameter);
            z_Pos = Random.Range(-diameter,diameter);
            // ������� ���������� ������� � ������
            GameObject organism = organisms[Random.Range(0, organisms.Count)];
            // ��������� ����� ������
            Vector3 spawnPos = new Vector3(
                x_Pos,
                organism.transform.position.y,
                z_Pos);
            // ������ ��'��� �� ����
            Instantiate(organism, spawnPos, organism.transform.rotation);
        }
        
    }
}
