using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float interactionRange = 3.0f;  // ��ȣ�ۿ� �Ÿ�
    public Camera playerCamera;            // �÷��̾��� ī�޶�

    private void Start()
    {
        // �÷��̾��� ī�޶� �������� ���� ���, �⺻ ī�޶� �ڵ����� �Ҵ�
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
            if (playerCamera == null)
            {
                Debug.LogError("Player camera is not assigned and no main camera found.");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryOpenDoor();
        }
    }

    private void TryOpenDoor()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player camera is not assigned.");
            return;
        }

        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        // Raycast ��θ� ��������� �ð�ȭ
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionRange, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            Debug.Log("Raycast hit: " + hit.transform.name); // Raycast �浹 Ȯ��

            if (hit.collider.CompareTag("Door"))
            {
                Door door = hit.collider.GetComponent<Door>();
                if (door != null)
                {
                    door.Move(); // ���� �̵���ŵ�ϴ�
                    Debug.Log("Door component found and moving door.");
                }
                else
                {
                    Debug.Log("No Door component found on the hit object.");
                }
            }
            else
            {
                Debug.Log("Raycast hit object does not have the 'door' tag.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object within interaction range.");
        }
    }
}