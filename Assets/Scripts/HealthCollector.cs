using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollector : MonoBehaviour
{
    public PlayerHealth PH;
    public HealthBar HB;

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PH.currentHealth = PH.maxHealth;
            HB.healthBar.value = PH.currentHealth;

        }
        GameObject.Destroy(this.gameObject);
    }
}
