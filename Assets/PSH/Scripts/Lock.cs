using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public Canvas lockUI; // �ڹ��� UI ������Ʈ

    private void Start()
    {
        lockUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư Ŭ��
        {
            // ���콺 Ŭ�� ��ġ�� ����ĳ��Ʈ�� ���� �ڹ��� ������Ʈ�� Ŭ���Ǿ����� Ȯ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // �ڹ��� ������Ʈ�� Ŭ������ ���
                {
                    if (lockUI != null)
                    {
                        lockUI.gameObject.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;


                    }
                }
            }
        }
    }
}
