using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private HealthBar hb;
    private int maxHealth = 100;
    private int currentHealth = -1;
    private int minHealth = 5;

    void Start()
    {
        hb.setMaxHealth(maxHealth);
        currentHealth = maxHealth; //Start game with maximum health
        
    }

    private void Update()
    {
        if (currentHealth < minHealth)
        {
            //End the game or something?
        }

        //TO CHANGE HEALTHBAR VALUES
        //
        //Call takeDamage or addHealth as required
        
    }

    private void takeDamage(int amount)
    {
        currentHealth -= amount;
        hb.setHealth(currentHealth);
    }

    private void addHealth(int amount)
    {
        currentHealth += amount;
        hb.setHealth(currentHealth);
    }
}
