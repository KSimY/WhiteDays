using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject gameOverUI;


    void Awake()
    {
        // ���� �� �� ���� �����ϵ��� ó��
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void showGameOverUI()
    {
        // ���� ���� UI ������Ʈ�� Ȱ��ȭ�Ѵ�.
        gameOverUI.SetActive(true);

        // ������Ʈ �ð��� 0������� �����Ѵ�. (�ð��� �����)
        Time.timeScale = 0;
    }
}
