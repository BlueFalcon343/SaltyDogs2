using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollectable : MonoBehaviour
{  
    void OnTriggerEnter2D(Collider2D other)
    {
        PirateController controller = other.GetComponent<PirateController>();

        if(controller != null)
        {
            if(controller.keyCount < 1)
            {
                controller.getKey(1);
                Destroy(gameObject);
            }
        }
    }
}
