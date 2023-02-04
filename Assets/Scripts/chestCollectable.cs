using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        PirateController controller = other.GetComponent<PirateController>();
       
        controller.PlaySound(collectedClip);
        
        if (controller != null)
        {
            controller.getScore(500);
            Destroy(gameObject);
            
        }
    }
}
