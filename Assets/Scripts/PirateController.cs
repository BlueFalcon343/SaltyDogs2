using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;


public class PirateController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject LevelSwitch;
    public float speed = 3.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public int keyCount;
    public int maxHealth;
    int currentHealth;
    private int score;
    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    public AudioSource audioSource;
  
  Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {        
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = TrackScore.totalScore;
        keyCount = 0;
        currentHealth = TrackScore.totalHealth;
        SetScoreText();
        SetHealthText();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();  
    }
        
    public void PlaySound (AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
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
       
        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (Input.GetKeyDown(KeyCode.R))
        {
            if(!PauseMenu.isPaused)
            {
                Launch();
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        TrackScore.totalScore = score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
        TrackScore.totalHealth = currentHealth;
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

        if (currentHealth <= 0)
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

    void dead()
    {
        SceneManager.LoadScene("Lose");
    }
}
