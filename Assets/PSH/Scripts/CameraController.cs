using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �迭 (Array)
    Transform[] camPositions = new Transform[1];

    // ����Ʈ (List)
    List<Transform> camList = new List<Transform>();

    FollowCamera followCam;
    float currentRate = 0;

    void Start()
    {
        // FollowCamera ������Ʈ�� ĳ���Ѵ�.
        followCam = Camera.main.gameObject.GetComponent<FollowCamera>();

        camList.Add(transform.GetChild(0));

        ChangeCamTarget(0);

    }

    void Update()
    {
        currentRate = Mathf.Clamp(currentRate, 0.0f, 0.0f);

        Camera.main.transform.position = Vector3.Lerp(camList[0].position, camList[0].position, currentRate);

    }

    void ChangeCamTarget(int targetNum)
    {
        // ���� ī�޶��� FollowCamera Ŭ������ �ִ� target�� 0�� ��Ҹ� �ִ´�.

        if (followCam != null)
        {
            // followCam.target = camPositions[targetNum];
            followCam.target = camList[targetNum];
        }
    }
}
