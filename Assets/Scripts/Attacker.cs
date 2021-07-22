using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 10f)] float currentSpeed = 1f;
    GameObject currentTarget; // The target that the attacker will be attacking
    Animator animator;

    private void Awake() // Gets called before everything else (execution order). When each attacker is spawned, we call this method.
    {
        FindObjectOfType<LevelController>().AttackersSpawned();

    }

    private void OnDestroy() // Gets called the very last thing (execution order). When the attacker is killed, we call this method.
    {
        // "Null reference exceptions" is when Unity is trying to find a reference for something which it cannot find (look at API)
        // This is how you ussually fix null references
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackersKilled();
        }

    }



    void Update()
    {
        move();
        UpdateAnimationState();
    }


    private void move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

    }

    public void SetMovementSpeed(float speed) // This method is so that we can use it in the "animation event" which we created, to set the speed. 
    {                                         // We created two animation events. One for the lizard's "animation-jump" (which we set the speed to zero from the start so that the lizard doesn't start moving while he's in the air)
        currentSpeed = speed;                 // And the other animation event was in the lizard "animatio - walk" which we set set the speed to 1 from the start so that the lizard start moving as soon as the jumping animation stops.
    }

    public void Attack(GameObject target)
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAttacking", true);

        currentTarget = target;

    }

    private void UpdateAnimationState() // If there is no target, start moving again
    {
        if (!currentTarget)
        {
            animator = GetComponent<Animator>(); // If I dont reference the animator controller, it won't work.***
            animator.SetBool("isAttacking", false);

        }
    }

    // Attacker subtracts health from the defender (deal damage)
    public void StrikeCurrentTarget(int Damage)
    {
        if (!currentTarget) { return; } // A mechanism where if we don't have a target, then dont do anything 
        Health health = currentTarget.GetComponent<Health>(); // Does the thing we are attacking have a health component.

        if (health) // If it does (health = true) then deal damage or subtract health
        {
            health.DealDamage(Damage);

        }
        
    }

}
