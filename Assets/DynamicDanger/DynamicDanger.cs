using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // �������� �� �������� 䳿
    public float objectSpeed = 5f; // �������� ��'����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
