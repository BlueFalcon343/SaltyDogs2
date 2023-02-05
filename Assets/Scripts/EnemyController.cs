using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool alive = true;
    private GameObject player;
    private GameObject p;
    private PirateController s;
    private Vector2 movement;
        
    [SerializeField]
    public float speed = 2f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {        
        Swarm();
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
    }

    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        PirateController character = other.gameObject.GetComponent<PirateController>();
        if(character != null)
        {
            character.ChangeHealth(-10);
            Destroy(gameObject);
        }
    }

    public void death()
    {
        alive = false;
        s = GameObject.Find("Pirate").GetComponent<PirateController>();
        s.getScore(100);
        Destroy(gameObject);
    }
}
