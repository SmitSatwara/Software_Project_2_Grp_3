using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private CharacterControll ccRef;

    public float maxHealth = 100;
    public float currentHealth = 100;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(100);
        ccRef = GetComponent<CharacterControll>();
    }

    void Die()
    {
        Debug.Log("Dead" + transform.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        //if(currentHealth < 0)
        //currentHealth = 0;
        if (currentHealth < 0)
            Die();

    }
}