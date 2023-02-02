using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
