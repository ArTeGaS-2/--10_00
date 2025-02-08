using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform target; // ֳ�� (��������)
    private NavMeshAgent agent; // ��������� ��� ��������
    private void Start()
    {
        // ��������� ��'��� � ��'�� "Player" �� ������ ���� ��������� Transform
        target = GameObject.Find("Player").GetComponent<Transform>();
        // ������ ��������� NavMeshAgent � ������� ������
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // �������� �� ������� ��������� ������
        if (target != null)
        {
            // ���������� ���� �� ���� ����������
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
