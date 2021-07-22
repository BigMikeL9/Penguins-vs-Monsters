using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] int damageAmount = 1;

    private void Start()
    {
 
    }


    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>(); //DONT FORGET THE "OTHER."
        var attacker = other.GetComponent<Attacker>();

        if (attacker && health) // this meanns that if the gameObject (other) we are colliding with has the components "Health" and "Attacker", then execute the code in between.
        {
            //Debug.Log("Hit: " + other.name);
            health.DealDamage(damageAmount);
            Destroy(gameObject);
        }
        
        
    }
}
