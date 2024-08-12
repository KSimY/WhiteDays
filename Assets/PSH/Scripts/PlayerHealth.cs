using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // �⺻ ü��
    public int currentHealth;
    public bool hasMap = false;
    public bool ishiding = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("ü������");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        print("ü��ȸ��");
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
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
}