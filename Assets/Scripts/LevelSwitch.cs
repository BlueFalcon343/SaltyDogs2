using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {           
        PirateController pirate = other.gameObject.GetComponent<PirateController>();
        
        if(pirate != null)
        {            
            SceneManager.LoadScene("SecondLevelScene");
        }   
    }
}
