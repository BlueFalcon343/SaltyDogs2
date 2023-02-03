using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;


public class PirateController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject LevelSwitch;
    public float speed = 3.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public int keyCount;
    public int maxHealth = 200;
    int currentHealth;
    private int score;
    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    


 Vector2 lookDirection = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = 0;
        keyCount = 0;
        currentHealth = maxHealth;
        SetScoreText();
        SetHealthText();
        animator = GetComponent<Animator>();
    }

    
    




    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);


     

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();

        }
       
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (Input.GetKeyDown(KeyCode.R))
        {
            Launch();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    
    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        SetHealthText();
        if(currentHealth <= 0)
        {
            dead();
        }
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 600);
    }
    public void getKey(int amount)
    {
        keyCount = keyCount + amount;
        Debug.Log(keyCount);
    }
    public void getScore(int amount)
    {
        score = score + amount;
        SetScoreText();
    }

    public void LevelTwo()
    {        
        transform.position = new Vector2(70,-15);
    }
    void dead()
    {

    }
}
