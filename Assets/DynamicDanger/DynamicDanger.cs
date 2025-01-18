using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // �������� �� �������� 䳿
    public float objectSpeed = 5f; // �������� ��'����

    private Rigidbody rb; // ����� ��� ���������� Rigidbody

    private float currentAngleMod = 1f; // �������� ����������� ����
    public float anglePerIteration = 90f; // �� �������� �������� ��� �� ���(��� �� ��������)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� ��������� ���������� rb
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 left = -transform.right;
        rb.velocity = left * objectSpeed * Time.deltaTime;
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo);
            transform.rotation = Quaternion.Euler(
                transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z + currentAngleMod); // + ��� �� ��������
            currentAngleMod += anglePerIteration; 
        }
    }
}
