using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{    
    void OnCollisionEnter2D(Collision2D other)
    {
        PirateController controller = other.gameObject.GetComponent<PirateController>();

        if (controller != null)
        {
            if (controller.keyCount >= 1)
            {
                controller.getKey(-1);
                Destroy(gameObject);
            }
        }
    }
}
