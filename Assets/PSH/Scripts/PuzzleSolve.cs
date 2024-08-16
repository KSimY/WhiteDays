using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolve : MonoBehaviour
{
    public GameObject effect;
    // ȸ������ üũ�� ������Ʈ��
    public Transform[] targetObjects;

    // üũ�� �� �� ȸ���� ������Ʈ
    public Transform objectToRotate;

    // ȸ�� �ִϸ��̼ǿ� �ʿ��� ������
    public float rotationDuration = 1.0f; // ȸ���� �Ϸ�Ǵ� �� �ɸ��� �ð�
    private float rotationStartTime; // ȸ���� ���۵� �ð�
    private Vector3 initialRotation; // �ʱ� ȸ����
    private Vector3 targetRotation; // ��ǥ ȸ����
    private bool isRotating = false; // ȸ�� ������ ����

    private void Update()
    {
        // targetObjects �迭�� ��� ������Ʈ�� x ȸ������ 0���� üũ
        bool allXRotationZero = true;
        foreach (var targetObject in targetObjects)
        {
            if (Mathf.Abs(targetObject.eulerAngles.x % 360) > 0.01f)  // x ȸ������ 0���� Ȯ��
            {
                allXRotationZero = false;
                break;
            }
        }

        // ��� ������Ʈ�� x ȸ������ 0�̸� ȸ�� �ִϸ��̼��� ����
        if (allXRotationZero && !isRotating)
        {
            StartRotation();
            Destroy(effect);
        }

        // ȸ�� �ִϸ��̼��� ���� ���̶�� ȸ���� ������Ʈ
        if (isRotating)
        {
            UpdateRotation();
        }
    }

    private void StartRotation()
    {
        // ȸ�� �ִϸ��̼� ���� �ʱ�ȭ
        initialRotation = objectToRotate.eulerAngles;
        targetRotation = new Vector3(initialRotation.x, 0, initialRotation.z);
        rotationStartTime = Time.time;
        isRotating = true;
    }

    private void UpdateRotation()
    {
        // ȸ�� �ִϸ��̼� ���� ��
        float elapsedTime = Time.time - rotationStartTime;
        float t = elapsedTime / rotationDuration;

        // LerpAngle�� ����Ͽ� �ε巯�� ȸ���� ���
        float newYRotation = Mathf.LerpAngle(initialRotation.y, targetRotation.y, t);
        objectToRotate.eulerAngles = new Vector3(initialRotation.x, newYRotation, initialRotation.z);

        // ȸ���� �Ϸ�Ǿ����� Ȯ��
        if (t >= 1.0f)
        {
            isRotating = false; // ȸ�� �Ϸ�
        }
    }
}