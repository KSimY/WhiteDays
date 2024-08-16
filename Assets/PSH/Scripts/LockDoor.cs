using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    private bool isLocked = true; // ���� ����ִ� ����

    // ���� ��� �����ϴ� �޼���
    public void UnlockDoor()
    {
        isLocked = false;
        // ���� �� �� �ִ� ���� �߰� (��: ��������Ʈ ����, �ִϸ��̼� ��� ��)
        Debug.Log("Door is now unlocked.");
        // ���� ���, ���� ���� ���� Ȱ��ȭ ���� ���� �Ǵ� �ִϸ��̼� Ʈ���Ÿ� �߰��� �� �ֽ��ϴ�.
    }

    private void Update()
    {
        if(isLocked == false)
        {
            Destroy(gameObject);
        }
    }
}