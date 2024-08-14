using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGetSc : MonoBehaviour
{
    public float pickRange = 1.5f;

    public MMSc mmsc;

    public Camera pCam;
    public Image defaultAim;
    public Image selectAim;

    public GameObject diary;
    public GameObject present;

    void Start()
    {
        selectAim.enabled = false;
        defaultAim.enabled = true;

        AddInitialItems();
    }

    void Update()
    {
        UpdateAim();
        if (Input.GetMouseButtonDown(0))
        {
            TryPickupItem();
        }
    }

    void UpdateAim()
    {
        Ray ray = new Ray(pCam.transform.position, pCam.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, pickRange))
        {
            if(hit.collider.GetComponent<Item>() != null || hit.collider.GetComponent<Paper1>() !=null)
            {
                defaultAim.enabled = false;
                selectAim.enabled =true;
            }
            else
            {
                defaultAim.enabled = true;
                selectAim.enabled = false;
            }
        }
        else
        {
            defaultAim.enabled = true;
            selectAim.enabled = false;
        }
    }

    void TryPickupItem()
    {
        Ray ray = new Ray(pCam.transform.position, pCam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickRange))
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item != null)
            {
                mmsc.AddItemToInventory(item);
                Destroy(item.gameObject);
                Debug.Log("������ ����:" + item.itemId);
                return;
            }

            Paper paper = hit.collider.GetComponent<Paper>();
            if (paper != null)
            {
                mmsc.AddPaperToInventory(paper);
                Destroy(paper.gameObject);
                Debug.Log("���� ����:" + paper.paperId);
                return;
            }
            Debug.Log("������ �����۵� �ƴ�");
        }
        else
        {
            Debug.Log("���� ���� �ƹ� ������Ʈ�� ����");
        }
    }

    void AddInitialItems()
    {
        if(diary !=null)
        {
            GameObject diaryItem = diary;
            Item item = diaryItem.GetComponent<Item>();
            if (item != null)
            {
                mmsc.AddItemToInventory(item);
                Debug.Log("���̾�� �κ��丮�� �߰��Ǿ����ϴ�.");
            }
        }
        if (present != null)
        {
            GameObject presentItem = present;
            Item item = presentItem.GetComponent<Item>();
            if(item != null)
            {
                mmsc.AddItemToInventory(item);
                Debug.Log("������ �κ��丮�� �߰��Ǿ����ϴ�.");
            }
        }
    }
}
