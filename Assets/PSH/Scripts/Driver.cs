using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public string driverName; // ����̹��� �̸�

    public void Collect()
    {
        // �÷��̾��� �κ��丮 ���¸� ������Ʈ�մϴ�.
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.SetDriver(true);
        }
        Debug.Log(driverName + " driver collected!");
        Destroy(gameObject); // ����̹��� �����ϸ� ������Ʈ�� �����մϴ�.
    }
}