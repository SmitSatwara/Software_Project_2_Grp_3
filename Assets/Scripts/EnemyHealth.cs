using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private CharacterControll ccRef;

    public float maxHealth;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
        
        ccRef = GetComponent<CharacterControll>();  
    }

    void Die()
    {
        Debug.Log("Dead"+transform.name);
        ccRef.Death();
        
    }

    public void Damage(float damageAmount)
    {
        currentHealth-=damageAmount;
        
        if (currentHealth < 0)
            Die();

        Destroy(GameObject.FindWithTag("Enemy"), 1f);

    }
}
