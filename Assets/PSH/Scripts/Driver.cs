using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public string DriverName; // ����̹��� �̸�

    // ���� ȹ�� �� ȣ��Ǵ� �޼ҵ�
    public void Collect()
    {
        Debug.Log(DriverName + " Paper collected!");
        Destroy(gameObject); // ����̹��� �����ϸ� ������Ʈ�� �����մϴ�.
    }
}