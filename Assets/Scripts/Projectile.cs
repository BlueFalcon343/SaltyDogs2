using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.gameObject.GetComponent<EnemyController>();
        if(e != null)
        {
            e.death();
        }
        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
                
    {
        EnemySpawner s = other.gameObject.GetComponent<EnemySpawner>();
        if (s != null)
        {
            s.hitCount();
        }
        Destroy(gameObject);
    }
}
