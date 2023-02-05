using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestScript : MonoBehaviour
{
    static MyTestScript testScript;
    static public int score;
    static public int health;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        testScript = gameObject.AddComponent<MyTestScript>();
    } 
}
