using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public PlayerHealth ph;
    public SoloText st;


    private void Update()
    {
        // ���� ���콺 ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� �� ��ũ��Ʈ�� �پ� �ִ� ������Ʈ���� Ȯ��
                if (hit.transform == transform)
                {
                    if (ph.isComplete == false)
                    {
                        st.Hon7();
                    }
                    else if(ph.isComplete == true)
                    {
                        // �޷������� �ִϸ��̼�, ���� ������ ����, ���� ���̵�ƿ� �Ǹ鼭 
                        // 3�� ������ ��ȯ
                        SceneManager.LoadScene(3);
                    }
                   
                }
            }
        }
    }
}