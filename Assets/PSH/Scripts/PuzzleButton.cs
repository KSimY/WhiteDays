using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public float targetRotationX = -90f;  // ��ǥ x ȸ����
    public float duration = 1f;           // ȸ�� �ִϸ��̼� �ð�

    private Vector3 startRotation;
    private Vector3 endRotation;
    private float elapsedTime = 0f;
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� Ȯ��
        {
            StartRotation();
        }

        if (isRotating)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            Vector3 result = Vector3.Lerp(startRotation, endRotation, t);

            print($"Start: {startRotation}, End: {endRotation}, Lerp: {result}");
            //transform.rotation = Quaternion.Euler(result);
            transform.eulerAngles = result;
            if (t >= 1f)
            {
                isRotating = false;
            }
        }
    }

    void StartRotation()
    {
        //transform.eulerAngles = transform.eulerAngles;

        // ���� ȸ������ �������� x�࿡ ���� ȸ���� ����
        //startRotation = new Vector3(targetRotationX, transform.eulerAngles.z, transform.eulerAngles.y);
        //targetRotationX -= 90;
        //endRotation = new Vector3(targetRotationX, transform.eulerAngles.y, transform.eulerAngles.z);

        Quaternion originRot = transform.rotation;


        elapsedTime = 0f;
        isRotating = true;
    }
}