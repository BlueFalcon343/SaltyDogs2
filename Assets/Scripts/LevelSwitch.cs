using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {     
        Debug.Log("step 1");
        PirateController pirate = other.gameObject.GetComponent<PirateController>();
        
        if(pirate != null)
        {
            Debug.Log("step 2");
            SceneManager.LoadScene("SecondLevelScene");
        }   
    }
}
