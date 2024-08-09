using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SMSSc : MonoBehaviour
{
    public Camera itemCamera;
    public RenderTexture renderTexture;
    public GameObject sms;

    void Start()
    {

    }

    public void ShowItem(GameObject itemPrefab)
    {
        if (sms != null)
        {
            Destroy(sms);
        }
        sms = Instantiate(itemPrefab);
        itemCamera.targetTexture = renderTexture;
        PositionItemInFrontOfCamera();
    }

    private void PositionItemInFrontOfCamera()
    {
        // ī�޶� �������� �߾ӿ��� ���ߵ��� ��ġ ����
        itemCamera.transform.position = new Vector3(0, 0, -5);
        itemCamera.transform.LookAt(sms.transform);
    }

    void Update()
    {
    }
    void OnDisable()
    {
        // �������� �ı��Ͽ� �޸� ����
        if (sms != null)
        {
            Destroy(sms);
        }
        itemCamera.targetTexture = null;
    }
}
