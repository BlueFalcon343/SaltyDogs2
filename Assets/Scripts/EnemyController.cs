using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool alive = true;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
        if(!alive)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if(!alive)
        {
            return;
        }
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PirateController player = other.gameObject.GetComponent<PirateController>();

        if(player != null)
        {
            player.ChangeHealth(-5);
            Destroy(gameObject);
        }
    }

    public void death()
    {
        alive = false;
        Destroy(gameObject);
    }
}
