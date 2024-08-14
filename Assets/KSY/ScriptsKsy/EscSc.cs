using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscSc : MonoBehaviour
{
    public GameObject player;
    public GameObject dalsu;
    public GameObject mm;
    private bool isChasing;

    public Canvas escCanvas;

    public TextMeshProUGUI[] menuOptions;
    private int selectedIndex = 0;

    private Canvas cuIn;

    private Color dC;
    private Color sC = Color.yellow;
    private Vector2[] dP;
    

    void Start()
    {
        escCanvas.gameObject.SetActive(false);

        dC = menuOptions[0].color;
        dP = new Vector2[menuOptions.Length];
        for(int i = 0; i < menuOptions.Length; i++)
        {
            dP[i] = menuOptions[i].rectTransform.anchoredPosition;
        }
        UpdateMenu();
    }

    void Update()
    {
        if (dalsu != null)
        {
            isChasing = dalsu.GetComponent<DalsuMove>().isChase;
        }
        cuIn = mm.GetComponent<MMSc>().currentInventory;
        if (Input.GetKeyDown(KeyCode.Escape) && !isChasing)
        {
            if (escCanvas.gameObject.activeSelf)
            {
                escCanvas.gameObject.SetActive(false);

                if(cuIn != null && cuIn.enabled == false)
                {
                    cuIn.enabled = true;
                    escCanvas.gameObject.SetActive(false);
                }
            }
            else
            {
                if (cuIn != null && cuIn.enabled == true)
                {
                    cuIn.enabled=false;
                }

                escCanvas.gameObject.SetActive(true);
                Cursor.visible = false;
                UpdateMenu();
                EventSystem.current.SetSelectedGameObject(menuOptions[selectedIndex].gameObject);
            }
        }

        if(escCanvas.gameObject.activeSelf)
        {
            HandleInput();
        }

    }


    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : menuOptions.Length - 1;
            UpdateMenu();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = (selectedIndex < menuOptions.Length - 1) ? selectedIndex + 1 : 0;
            UpdateMenu();
        }

        // �����̽��ٷ� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectOption();
        }
    }

    private void UpdateMenu()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedIndex)
            {
                // ���õ� ������ �ð��� ȿ��
                menuOptions[i].rectTransform.anchoredPosition = dP[i] + new Vector2(20, 0);
                menuOptions[i].color = sC;
            }
            else
            {
                menuOptions[i].rectTransform.anchoredPosition = dP[i];
                menuOptions[i].color = dC;
            }
        }
    }
    private void SelectOption()
    {
        switch (selectedIndex)
        {
            case 0:
                // ���� �̾��ϱ�
                escCanvas.gameObject.SetActive(false);
                Cursor.visible = false;
                break;
            case 1:
                // �κ�� ���ư���
                SceneManager.LoadScene(3); // 0�� ������ ���ư���
                // ���� ���Ƿ� ġƮ�� ���� ����� �ٲ�׽��ϴ�
                break;
            case 2:
                // �����ϱ�
                Application.Quit();
                break;
            
        }
    }
}
