using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestCollectable : MonoBehaviour
{
   public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        PirateController controller = other.GetComponent<PirateController>();
                      
        if (controller != null)
        {
            controller.PlaySound(collectedClip);
            controller.getScore(500);
            Destroy(gameObject);
        }
    }
}
