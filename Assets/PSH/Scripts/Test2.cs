using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public PlayerInventory playerInventory; // PlayerInventory �ν��Ͻ�

    private void Update()
    {
        // �÷��̾ Nipper�� ������ �ִ��� Ȯ��
        if (playerInventory != null && playerInventory.hasNipper)
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
                    if (hit.transform.gameObject == gameObject)
                    {
                        // ���� ������Ʈ�� �ı�
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}