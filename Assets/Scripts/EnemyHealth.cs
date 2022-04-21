using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyController ccRef;

    public float maxHealth;
    public float currentHealth;

    

    void Start()
    {
        currentHealth = maxHealth;

        ccRef = GetComponent<EnemyController>();
    }

    void Die()
    {
        
        Debug.Log("Dead "+ transform.name);

        
        ccRef.Death();
        Destroy(gameObject,1f);

    }

    private void WaitForSeconds(int v)
    {
        throw new NotImplementedException();
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            Die();
        }
            

        //Destroy(this.gameObject, 1f);

    }
   
}