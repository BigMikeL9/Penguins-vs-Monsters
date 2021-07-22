using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) // When a different collider/gamObject "stays" within this graveStone's gameObject. 
    {
        Attacker attacker = other.GetComponent<Attacker>();

        if (attacker) // If the thing that bumped into me is an attacker...
        {
            //Then do something in here
        }
    }

}
