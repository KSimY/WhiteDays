using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float targetZ = 10f; // �̵��� ��ǥ Z ��ǥ
    public float moveDuration = 1f; // �̵� �ð�

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = new Vector3(originalPosition.x, originalPosition.y, targetZ);
    }

    public void Move()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCoroutine());
        }
    }

    private IEnumerator MoveCoroutine()
    {
        isMoving = true;
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // ��Ȯ�� ��ġ ����
        isMoving = false;
    }
}