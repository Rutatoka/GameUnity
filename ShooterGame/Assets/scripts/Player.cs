using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public int score;
    private AudioSource audioSource;
  
    [Header("effects")]
    public GameObject salveEffect;
    public GameObject shieldEffect;
    public GameObject shield;
    public GameObject aura;

    [Header("music")]
    public GameObject soundSalve;
    public GameObject soundShield;
    public GameObject soundKey; 
    public AudioClip[] soundStep;
    public GameObject soundDoor;
 
    [Header("controls")]
    public float speed;
    public int health;
    public GameObject PanelDeath;
    public GameObject PanelWin;
    public Bonus shieldTimer;


    [Header("Text")]
    public Text textScore;
    public Text healthDisplay;
    public Text DisplayName;


    [Header("Key")]
    public GameObject keyIcon;
    public GameObject keyEffect;


    private void Start()
    {
      
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = "" + health; 
        DisplayName.text = PlayerPrefs.GetString("playerName");
        textScore.text = PlayerPrefs.GetInt("Score").ToString();
    }

   

private void Update()
    {
       
        PlayerPrefs.SetInt("Score", score);
        
      
        if (health >= 20)
        {
            health = 20;
            healthDisplay.text = "" + health;
        }
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
       
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        if (facingRight == false && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput.x < 0)
        {
            Flip();
        }

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (health <= 0)
        {
            PanelDeath.SetActive(true);
            Destroy(gameObject);        
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 19;
            aura.SetActive(true);
        }
        else
        {
            speed = 8;
            aura.SetActive(false);
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
 
    private void StepSoundPlay()
    {
        audioSource.PlayOneShot(soundStep[Random.Range(0, soundStep.Length)]);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Salve"))
        {
            ChangeHealth(5);
            Instantiate(salveEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Instantiate(soundSalve, transform.position, Quaternion.identity);
        }
        else if (other.CompareTag("Shield"))
        {
            if (!shield.activeInHierarchy)
            {
                shield.SetActive(true);
                
                shieldTimer.gameObject.SetActive(true);
                shieldTimer.isCooldown = true;  
                
                Instantiate(soundShield, transform.position, Quaternion.identity);
                Instantiate(shieldEffect, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            else
            {
              
                shieldTimer.ResetTimer();
                Destroy(other.gameObject);
            }
        }
        else if (other.CompareTag("Key"))
        {
            if (keyIcon.activeInHierarchy)
            {
            }
            else if (!keyIcon.activeInHierarchy)
            {
                Instantiate(soundKey, transform.position, Quaternion.identity);
                keyIcon.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Door") && keyIcon.activeInHierarchy)
        {
            Instantiate(keyEffect, other.transform.position, Quaternion.identity);
            keyIcon.SetActive(false);
            other.gameObject.SetActive(false);
            Instantiate(soundDoor, transform.position, Quaternion.identity);

        }

        if (other.CompareTag("Exit") || Input.GetKey(KeyCode.Escape))
        {
            //SceneManager.LoadScene(2);
           
            PanelWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ChangeHealth(int healthValue)
    {
        if (!shield.activeInHierarchy || shield.activeInHierarchy&& healthValue > 0)
        {
            health += healthValue;
            healthDisplay.text = "" + health;
        }
        else if (shield.activeInHierarchy && healthValue < 0)
        {
            shieldTimer.ReduseTime(healthValue);
        }
    }

    public void Kill()
    {
         score++;
        textScore.text = PlayerPrefs.GetInt("Score").ToString();    
    }
}
