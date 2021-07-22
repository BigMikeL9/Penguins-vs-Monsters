using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour // This script is suppose to be called "AttackerSpawner".
{

    [SerializeField] GameObject[] enemiesPrefabs; // "Attacker" type refers to the script attached to the enemy Prefab.
    [SerializeField] float maxSpawnTime = 5;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] AudioClip spawnSFX;


    private bool spawn = true;

    //This method will keep going as long as "while(...)" is true. Which is why it is useful to make the Start() method an Ienumerator.
    IEnumerator Start()
    {
        while (spawn) 
        {
            float timeBetweenSpawns = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(timeBetweenSpawns);
            SpawnRandomEnemy();
        }
        
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnRandomEnemy()
    {
        var enemyPrefabIndex = Random.Range(0, enemiesPrefabs.Length);
        GameObject newAttacker = Instantiate(enemiesPrefabs[enemyPrefabIndex], transform.position, Quaternion.identity) as GameObject; // "Attacker is referring to the "Attacker" script/class that's on the enemyPrefab.
        newAttacker.transform.parent = transform;        // The parent of each instantiated enemyPrefab is the "Spawner" GameObject they are spawning from, which contains the "spawner" script.
                                                         // parent transform = newAttacker transform            // This will allow us to spawn a new attacker as a child to the game object which instantiated it. (In other words)
                                                         // The purpose of doing this is so that we can tell the defenders whether to shoot or not depending on if there is an instantiated enemy in their lane.
                                                         // ** by setting the transform of one gameobject as the parent tranform of another game object’s transform . So the transform after the equal sign will be set as the parent transform of the newattacker transform. https://community.gamedev.tv/t/a-question-about-newattacker-transform-parent-transform/142946
        GetComponent<AudioSource>().PlayOneShot(spawnSFX);
    }
}
