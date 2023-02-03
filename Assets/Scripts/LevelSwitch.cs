using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
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
        Debug.Log("step 1");
        PirateController pirate = other.gameObject.GetComponent<PirateController>();
        
        if(pirate != null)
        {
            Debug.Log("step 2");
            pirate.LevelTwo();
        }   
    }
}
