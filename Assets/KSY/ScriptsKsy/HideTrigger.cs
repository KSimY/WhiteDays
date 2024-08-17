using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTrigger : MonoBehaviour
{
    // PlayerHealth �ν��Ͻ� ������ ���� ����
    public PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        // �±װ� "Player"�� ������Ʈ�� �ݶ��̴��� ����� ��
        if (other.CompareTag("Player"))
        {
            // PlayerHealth ��ũ��Ʈ�� isHiding ������ true�� ����
            if (playerHealth != null)
            {
                playerHealth.ishiding = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �±װ� "Player"�� ������Ʈ�� �ݶ��̴��� ����� ��
        if (other.CompareTag("Player"))
        {
            // PlayerHealth ��ũ��Ʈ�� isHiding ������ false�� ����
            if (playerHealth != null)
            {
                playerHealth.ishiding = false;
            }
        }
    }
}