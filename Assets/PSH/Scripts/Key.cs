using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyName; // ������ �̸�

    // ���� ȹ�� �� ȣ��Ǵ� �޼ҵ�
    public void Collect()
    {
        Debug.Log(keyName + " key collected!");
        Destroy(gameObject); // ���踦 �����ϸ� ������Ʈ�� �����մϴ�.
    }
}