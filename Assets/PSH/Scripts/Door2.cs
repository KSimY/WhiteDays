using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public float rotationAngle = 90f; // ȸ���� ���� (�� ����)
    public float rotationDuration = 1f; // ȸ���� �ð� (��)

    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool rotatingToTarget = false;
    private float rotationStartTime;

    void Start()
    {
        originalRotation = transform.rotation;
        // ��ǥ ȸ��: ���� ȸ�� ���¿� y�� �������� rotationAngle ��ŭ ȸ��
        targetRotation = originalRotation * Quaternion.Euler(0, rotationAngle, 0);
    }

    void Update()
    {
        // ���콺 ���� Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� �� ��ũ��Ʈ�� �پ� �ִ� ������Ʈ���� Ȯ��
                if (hit.transform == transform)
                {
                    if (!isRotating)
                    {
                        if (rotatingToTarget)
                        {
                            // ���� ȸ�� ���·� ���ư�����
                            StopAllCoroutines();
                            StartCoroutine(RotateToOriginal());
                        }
                        else
                        {
                            // ��ǥ ȸ������ ȸ���ϵ���
                            StartCoroutine(RotateToTarget());
                        }
                    }
                }
            }
        }

        // ȸ�� �߿��� �ε巴�� ȸ���ϵ��� ó��
        if (isRotating)
        {
            float elapsedTime = Time.time - rotationStartTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            Quaternion startRotation = rotatingToTarget ? originalRotation : targetRotation;
            Quaternion endRotation = rotatingToTarget ? targetRotation : originalRotation;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            // ȸ�� �Ϸ� üũ
            if (t >= 1f)
            {
                isRotating = false;
                rotatingToTarget = !rotatingToTarget; // ȸ�� ���� ��ȯ
            }
        }
    }

    private System.Collections.IEnumerator RotateToTarget()
    {
        isRotating = true;
        rotatingToTarget = true;
        rotationStartTime = Time.time;
        yield return null;
    }

    private System.Collections.IEnumerator RotateToOriginal()
    {
        isRotating = true;
        rotatingToTarget = false;
        rotationStartTime = Time.time;
        yield return null;
    }
}