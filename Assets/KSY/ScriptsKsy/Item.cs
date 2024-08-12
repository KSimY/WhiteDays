using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int itemId;
    public string itemName;
    public Sprite iconImage;
    public GameObject itemModel;
    public string description;
    public bool hasFun;


    private void Start()
    {
    }

    public void Use()
    {
        if(!hasFun)
        {
            Debug.Log("�� �������� �ƹ��� ��ɵ� �����ϴ�.");
            return;
        }
        Debug.Log("���� �������� :" + itemId);
        switch(itemId)
        {
            case 0:
                SoyMilk();
                break;
            case 1:
                Soju();
                break;
            default:
                Debug.Log("������ ID�� �νĵ��� �ʾҾ��");
                break;
        }
    }

    private void SoyMilk()
    {
        PlayerHealth ph = FindObjectOfType<PlayerHealth>();
        if(ph != null)
        {
            ph.Heal(1);
        }
        else
        {
            Debug.LogError("PlayerHealth�� ���� ����");
        }
    }

    private void Soju()
    {
        PlayerHealth ph = FindAnyObjectByType<PlayerHealth>();
        if(ph != null)
        {
            ph.TakeDamage(1);
        }
        else
        {
            Debug.LogError("PlayerHealth�� ���� ����");
        }
    }

}



