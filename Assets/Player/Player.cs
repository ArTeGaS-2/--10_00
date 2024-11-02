using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera; // �������� �� ������� ������
    private static float cameraDistance = 7f; // ������ ������
    private static float cameraRetreat = -0.1f; // ³����� ������ (����)
    private static float cameraDistanceMod; // ���������� ������
    private static float cameraRetreatMod; // ���������� �������

    public float maxSpeed = 10f; // ����������� �������� ������
    public float forceTime = 1f; // ��� 䳿 �������
    public float forceMultiplier = 100f; // ������� ����

    public float animTime = 20f; // ��� 䳿 �������

    private Rigidbody rb; // ��������� �� �������� ���������

    public float divider = 2f; // ������� �� ��� �� ����� ��� ������� ���������

    public static Vector3 scaleMod; // ���������� ������
    private static Vector3 currentScale; // �������� �����
    private static float forwardMod; // ����������� � �������
    private static float sideMod; // ����������� � ������
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentScale = transform.localScale; // ����'����� �������� ����� �� "currentScale"

        scaleMod = transform.localScale / divider; // �������� �� ��� ���� ������������ �����

        forwardMod = currentScale.z * 1.3F;
        sideMod = currentScale.x * 0.8f;

    }
    // ���� ����� ������, ���� ����������� �� ������ ����������� ��� �������
    public static void AddScale()
    {
        currentScale = currentScale + scaleMod;

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;

    }
    public static void AddCameraDistance()
    {
        cameraDistance = currentScale.x;
        cameraRetreatMod = 1f + (currentScale.x / 7f);
    }
    private void Update()
    {

        // �������� ������� ���� � ������� �����������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // ��������� �������� �� ������� �� ����� �������
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0;

            // ��������� ������� � �������� �� �������
            if (direction.magnitude > 0.1f) // ��� �������� ������� ���������
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f);
            }

            // ������ ��������� ��� ������� ��� (˳�� ������ ����)
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(direction * forceMultiplier
                    * Time.deltaTime, ForceMode.Acceleration);
                // �������� ����������� ��������
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
                SlimeMoveAnim();
            }
            else
            {
                SlimeStopAnim();
            }
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            cameraDistance + cameraDistanceMod,
            cameraRetreatMod);
            
    }
    private void SlimeMoveAnim()
    {
        // ������ ������� �����
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            currentScale.z,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            currentScale.x,
            Time.deltaTime / animTime);


        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
    private void SlimeStopAnim()
    {
        // ������ ������� �����
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1f,
            Time.deltaTime / animTime);
        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            1f,
            Time.deltaTime / animTime);


        transform.localScale = new Vector3(
            sideScale,
            transform.localScale.y,
            forwardScale);
    }
}
