using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    //[SerializeField] private HealthBar hb;
    public OxygenBar ob;
    //private int maxHealth = 100;
    //private int currentHealth = -1;
    //private int minHealth = 5;

    void Start()
    {
        //hb.setMaxHealth(maxHealth);
        //currentHealth = maxHealth; //Start game with maximum health
        ob.setOxygen();
        
    }

    public void Update()
    {
         if (ob.oxygenBarValue.Equals("0"))
         {
            SceneManager.LoadScene("loss");
         }


        ob.udpate(); 
        //NG commented out, causes exception at runtime, null ref err
        //TO CHANGE HEALTHBAR VALUES
        //
        //Call takeDamage or addHealth as required
        
    }

    // private void takeDamage(int amount)
    // {
    //     currentHealth -= amount;
    //     hb.setHealth(currentHealth);
    // }

    // private void addHealth(int amount)
    // {
    //     currentHealth += amount;
    //     hb.setHealth(currentHealth);
    // }
}
