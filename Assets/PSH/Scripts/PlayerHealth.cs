using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // �⺻ ü��
    public int currentHealth;
    public bool hasMap = false;
    public bool ishiding = false;

    public Canvas gameCanvas; // ĵ���� UI�� public ������ ����

    void Start()
    {
        currentHealth = maxHealth;

        // �ʱ� ĵ���� ���� ����
        UpdateCanvasVisibility();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("ü������");
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            UpdateCanvasVisibility(); // ü�� ���� �� ĵ���� ���� ������Ʈ
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        print("ü��ȸ��");
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateCanvasVisibility(); // ü�� ȸ�� �� ĵ���� ���� ������Ʈ
    }

    void Die()
    {
        Debug.Log("Player has died");
        gameObject.SetActive(false);
        GameManager.gm.showGameOverUI();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void GetMap()
    {
        hasMap = true;
    }

    // ĵ���� Ȱ��ȭ ���θ� ������Ʈ�ϴ� �޼���
    private void UpdateCanvasVisibility()
    {
        if (gameCanvas != null)
        {
            // currentHealth�� 3 �̸��� �� ĵ���� Ȱ��ȭ
            gameCanvas.gameObject.SetActive(currentHealth < 3);
        }
    }
}