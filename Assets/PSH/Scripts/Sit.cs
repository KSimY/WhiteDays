using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    // �ʱ� ������ ��
    private Vector3 initialScale = new Vector3(0.4f, 0.6f, 0.4f);

    // ������ ������ ��
    private Vector3 scaledDown = new Vector3(0.2f, 0.3f, 0.2f);

    // ���� ������ ����
    private Vector3 targetScale;

    private void Start()
    {
        // �ʱ� ������ ����
        transform.localScale = initialScale;
        targetScale = initialScale;
    }

    private void Update()
    {
        // ���� ��Ʈ�� Ű�� ���ȴ��� üũ
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // ���� ��Ʈ�� Ű�� ������ �������� ����
            targetScale = scaledDown;
        }
        else
        {
            // Ű�� ������ ������ ���� �����Ϸ� ���ư�
            targetScale = initialScale;
        }

        // �������� ����
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 5f);
    }
}