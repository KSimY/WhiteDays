using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public string PaperName; // ������ �̸�

    // ���� ȹ�� �� ȣ��Ǵ� �޼ҵ�
    public void Collect()
    {
        Debug.Log(PaperName + " Paper collected!");
        Destroy(gameObject); // ���̸� �����ϸ� ������Ʈ�� �����մϴ�.
    }
}