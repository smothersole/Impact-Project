using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float hunger;
    public float hungerDrainRate;
    public int maxHealth = 4;
    public int currentHealth;
    bool eat;

    public health_bar healthBar;
    public hunger_bar hungerBar;
    public pause_menu pause;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        hungerBar.SetMaxHunger(hunger);
    }

    void Update()
    {
        if(currentHealth == 0)
        {
            pause.LoadMenu();
        }
    }

    
    void LateUpdate()
    { 
        //hunger system
        if(hunger <= 0)
        {
            hunger = 0;
        }
        else
        {
            hunger -= hungerDrainRate * Time.deltaTime;
            hungerBar.SetHunger(hunger);
        }
        //Debug.Log(hunger);
    }

    public void AddHunger(float val)
    {
        hunger += val;
        hungerBar.SetHunger(hunger);
        if(hunger > 100f)
        {
            hunger = 100f;
        }
    }

    void OnTriggerEnter(Collider col)
    {        
        if(col.gameObject.CompareTag("Predator"))
        {
            Debug.Log("Ouch!");
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }
    }

    
}
