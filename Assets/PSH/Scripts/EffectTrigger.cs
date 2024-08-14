using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    public GameObject targetObject; // ���̵� ���� ������ ��� ������Ʈ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // targetObject�� Fade ��ũ��Ʈ�� ������ �ִ��� Ȯ��
            Fade fadeScript = targetObject.GetComponent<Fade>();
            if (fadeScript != null)
            {
                fadeScript.StartFading(); // ���̵� ���� �����ϴ� �޼��� ȣ��
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Target object does not have a Fade script.");
            }
        }
    }
}