using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public float interactionRange = 3.0f; // ������� ��ȣ�ۿ� �Ÿ�
    public Camera playerCamera; // �÷��̾��� ī�޶�

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // �⺻ ī�޶� �ڵ����� �Ҵ�
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryCollectKey();
        }
    }

    void TryCollectKey()
    {
        RaycastHit hit;

        // ī�޶��� �������� Raycast�� ��Ƽ� ���踦 �����մϴ�.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            Key key = hit.collider.GetComponent<Key>();

            if (key != null)
            {
                key.Collect(); // ���踦 �����մϴ�.
            }
        }
    }
}