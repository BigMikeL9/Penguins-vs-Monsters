using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        
        // If this is a gravestone, jump. We can use a tag but then we'd use a string.
        // We're creating a script/component just for the gravestone to identify it here, instead of giving it a tag. (Its a bad habit to create an empty script just to create identify something as a class)
        
        if (otherObject.GetComponent<GraveStone>())
        {
            animator = GetComponent<Animator>();
            animator.SetTrigger("jumpTrigger");

        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other.gameObject);

        }
      
    }

}
