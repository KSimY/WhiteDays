using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        // ���콺 ���� ��ư Ŭ���� �����Ǿ����� Ȯ��
        if (Input.GetMouseButtonDown(0)) // 0�� ���� ���콺 ��ư
        {
            // Ŭ���� ��ġ�� ȭ�鿡�� ���� ��ǥ�� ��ȯ
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast�� ����Ͽ� Ŭ���� ������Ʈ ����
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� ���� ��ũ��Ʈ�� �پ� �ִ� ������Ʈ���� Ȯ��
                if (hit.transform == transform)
                {
                    // ������Ʈ�� ����
                    Destroy(gameObject);
                }
            }
        }
    }
}
