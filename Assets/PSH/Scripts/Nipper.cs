using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nipper : MonoBehaviour
{
    public string nipperName; // ������ �̸�

    public void Collect()
    {
        // �÷��̾��� �κ��丮 ���¸� ������Ʈ�մϴ�.
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.SetNipper(true);
        }
        Debug.Log(nipperName + " nipper collected!");
        Destroy(gameObject); // ���۸� �����ϸ� ������Ʈ�� �����մϴ�.
    }
}