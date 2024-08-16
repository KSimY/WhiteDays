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

    public IEnumerator Hon1()
    {
        honCan.enabled = true;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        honText.text = "�ҿ��̴� 2�г� 8���̴�.";
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon2()
    {
        honCan.enabled = true;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        honText.text = "�� ���̴�.";
        yield return new WaitForSeconds(2);
        honText.text = "å���̿��� ������ ��εǾ� �ִ�.";
        yield return new WaitForSeconds(3);
        honText.text = "������ ���ϵ� ������ ������ �� �� ����.";
        yield return new WaitForSeconds(3.5f);
        honCan.enabled = false;
    }
    public IEnumerator Hon3()
    {
        honCan.enabled = true;
        honText.text = "������ ȹ���ߴ�.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon4()
    {
        honCan.enabled = true;
        honText.text = "�������� ȹ���ߴ�.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon5()
    {
        honCan.enabled = true;
        honText.text = "������ ȹ���ߴ�.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon6()
    {
        honCan.enabled = true;
        honText.text = "���� ����ִ�.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon7()
    {
        honCan.enabled = true;
        honText.text = "������ ���� �� ����.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon8()
    {
        honCan.enabled = true;
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        honText.text = "������ �����־���.";
        yield return new WaitForSeconds(2);
        honText.text = "�б����� ������.";
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
    public IEnumerator Hon9()
    {
        honCan.enabled = true;
        honText.text = "�� �ڸ��� �ƴϴ�.";
        AudioSource.PlayClipAtPoint(hon, hm.transform.position);
        yield return new WaitForSeconds(2);
        honCan.enabled = false;
    }
}
