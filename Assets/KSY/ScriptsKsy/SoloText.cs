using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoloText : MonoBehaviour
{
    public Canvas honCan;
    public TextMeshProUGUI honText;
    public GameObject hm;
    public AudioClip hon;

    void Start()
    {
        honCan.enabled = false;
    }

    void Update()
    {
        
    }

    public void Hon1()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "�ҿ��̴� 2�г� 8���̴�.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon2()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "å���̿��� ������ ��εǾ� �ִ�.";
        Destroy(honCan2.gameObject, 3);
    }
    public void Hon3()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "������ ȹ���ߴ�.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon4()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "�������� ȹ���ߴ�.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon5()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "������ ȹ���ߴ�.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon6()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text =  "���� ����ִ�.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon7()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "������ ���� �� ����.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon8()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "������ �����־���.";
        Destroy(honCan2.gameObject, 2);
    }
    public void Hon9()
    {
        Canvas honCan2 = Instantiate(honCan);
        honCan2.enabled = true;
        honCan.enabled = false;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position, 0.7f);
        honCan2.GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text = "�� �ڸ��� �ƴϴ�.";
        Destroy(honCan2.gameObject, 2);
    }
}
