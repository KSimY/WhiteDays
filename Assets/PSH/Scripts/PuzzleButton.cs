using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public float targetRotationX = -90f;  // ��ǥ x ȸ����
    public float duration = 1f;           // ȸ�� �ִϸ��̼� �ð�

    private bool isStart = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStart) // ���콺 ���� ��ư Ŭ�� Ȯ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� ���� ��ũ��Ʈ�� �پ��ִ� ������Ʈ���� Ȯ��
                if (hit.transform == transform)
                {
                    StartCoroutine(RotRoutine(duration, targetRotationX));
                }
            }
        }
    }

    IEnumerator RotRoutine(float time, float degree)
    {
        isStart = true;

        int count = 0;
        int wholeCount = (int)(time / 0.02f);

        while (count < wholeCount)
        {
            count++;
            transform.Rotate(new Vector3(0, degree * 0.02f, 0));

            yield return null;
        }

        isStart = false;
    }
}