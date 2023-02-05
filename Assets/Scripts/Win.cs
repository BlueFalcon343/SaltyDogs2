using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D other)
    {
        PirateController controller = other.GetComponent<PirateController>();

        if (controller != null)
        {
            SceneManager.LoadScene("Win");
        }
    }
}