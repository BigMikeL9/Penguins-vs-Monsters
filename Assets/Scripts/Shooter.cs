using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun; // when you make the type of the variable "GameObject", you can drag any gameObject in there, which why it is better to make the type of the variable of the GameObject the Script/Class thats on that gameObject that we are dragging into the [serializefield] is the unity interface.
                                                       // instead of adding another line of code for "gun" ([SerializeField] GameObject gun;), we can just add a comma after the "projectilePrefab" and add the "gun" there which adds two seperate variables since they are both of the same type.
    [SerializeField] AudioClip shootingSFX;

    private AudioSource audioSource;
    Spawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // This creates a parent for the instantiated projectile prefabs to be placed under. Check the "DefenderSpawner" script/class for more description. Did something similar for the Defenders.
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME); 
        }
    }

    private void Update()
    {
        CheckIfAttackerIsInLane();
    }


    // This method checks if the attacker is in lane, and then plays the plays the "isAttacking" animation if there is an enemy, which has an animation event that fire() the projectile.
    private void CheckIfAttackerIsInLane()
    {
        if (IsAttackerInLane())
        {
            // TODO: Change animation state to shooting
            animator.SetBool("isAttacking", true);
            //Debug.Log("Shoot");
        }
        else
        {
            // TODO: Change animation state to idle
            animator.SetBool("isAttacking", false);
            //Debug.Log("Sit and Wait");
        }
    }

    private void fire()
    {
        /* We add "GameObject newprojectile = " and "as GameObject" before and after the instantiate method because it makes the instantiated object a GameObject, 
           which gives us much more control over it and makes us do things to it that we wouldn't be able to do if was just an Object. 
           Without the "GameObject newprojectile = " and "as GameObject", the instantiated object will just be an object not givving us much control over it. */
        GameObject newprojectile =  Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity) as GameObject;
        newprojectile.transform.parent = projectileParent.transform; // Places the instantiated projectilePrefabs under the "projectileParent" gameObject in the inspector. To keep the heirarchy clean.
        audioSource.PlayOneShot(shootingSFX, 1f);
    }


    // Create an array to store each of the Attacker Spawners
    private void SetLaneSpawner() // ***MMMMMM*** Gets the spawner's GameObject location in relation to the spawned defender (that we placed) location.
    {
        //Create a variable that holds an array of all the spawners that we have in the level.
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        //Debug.Log("AttackSpawners in Scene : " + spawners.Length);

        foreach (Spawner spawner in spawners)
        {
            // A bool that returns true if the shooter(defender that shoots) is in the same lane as the spawner GameObject (which we referenced/found using the "FindObjectsOfType<Spawner>()".
            // isCloseEnough = (Each spawner's y position (getting each by using the "foreach" loop) - the y position of the gameObject that this script/class is attached to (defender that shoots) <= 0 or tinniest fraction close to 0 (using "Mathf.Epsilon" because there might be a tiny tiny fraction that is more than 0).
            // Need to use "Maths.abs" to prevent us from having a negative value, which will be smaller than 0 or "Mathf.Epsilon" and return true. 
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough) // if equals to true
            {
                // then the "myLaneSpawner" (variable referencing the spawner script/class) is EQUAL to the "spawner" that we just looped through in our "foreach" (which) we found using "FindObjectsOfType<Spawner>();" in the array;
                myLaneSpawner = spawner;
            }
            /* else
            {
                Debug.Log("isCloseEnough wasn't true");
            } */
        }
    }


    // Create a mechanism to shoot or not shoot based upon whether we have an attacker in our lane.
    private bool IsAttackerInLane() // Checks if there is an attacker in our lane (by checking if the "spawner" gameobjects have any children, which is where the enemyPrefabs are placed under depending on which "spawner" gameObject instantiated them)
    {
        // if my lane spawner child count is less than or equal to 0
            // return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false; 
        }
        else
        {  
            return true;

        }
    }
}
