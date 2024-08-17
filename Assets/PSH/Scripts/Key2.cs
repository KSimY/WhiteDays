using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour
{
    public string keyName; // ������ �̸�

    public void Collect()
    {
        // �÷��̾��� �κ��丮 ���¸� ������Ʈ�մϴ�.
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.SetKey2(true);
        }
        Debug.Log(keyName + " key collected!");
        Destroy(gameObject); // ���踦 �����ϸ� ������Ʈ�� �����մϴ�.
    }
}
