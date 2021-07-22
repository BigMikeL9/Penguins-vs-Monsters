using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameObject projectileVFX;
    [SerializeField] int currencyAddition = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    private void Die()
    {
        if (health <= 0)
        {
            triggerDeathVFX();
            FindObjectOfType<Currency>().AddCurrency(currencyAddition);
            Destroy(gameObject);
        }
    }

    private void triggerDeathVFX()
    {
        if (projectileVFX == null) // another way => if (!projectileVFX) 
        {                          // this is just to avoid getting an error if we forget to add a VFX in the serializefield.
            return;
        }

        GameObject deathVFX = Instantiate(projectileVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(deathVFX, 1f);
    }
}
