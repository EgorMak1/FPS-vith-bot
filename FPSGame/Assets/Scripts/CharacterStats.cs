using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //public int currentHealth { get; private set; }

    public int damage;
    public int maxHealth;

    //void Awake()
    //{
    //    currentHealth = maxHealth;
    //}

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");
         if(maxHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
