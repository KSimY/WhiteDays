using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            TryCollectPaper();
            TryCollectDriver();
            TryCollectNipper();
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
    void TryCollectPaper()
    {
        RaycastHit hit;

        // ī�޶��� �������� Raycast�� ��Ƽ� ���̸� �����մϴ�.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            Paper1 paper = hit.collider.GetComponent<Paper1>();

            if (paper != null)
            {
                paper.Collect(); // ���̸� �����մϴ�.
            }
        }
    }
    void TryCollectDriver()
    {
        RaycastHit hit;

        // ī�޶��� �������� Raycast�� ��Ƽ� ����̹��� �����մϴ�.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            Driver driver = hit.collider.GetComponent<Driver>();

            if (driver != null)
            {
                driver.Collect(); // ����̹��� �����մϴ�.
            }
        }
    }

    void TryCollectNipper()
    {
        RaycastHit hit;

        // ī�޶��� �������� Raycast�� ��Ƽ� ���۸� �����մϴ�.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            Nipper nipper = hit.collider.GetComponent<Nipper>();

            if (nipper != null)
            {               
               nipper.Collect(); // ���۸� �����մϴ�.
            }
        }
    }
}