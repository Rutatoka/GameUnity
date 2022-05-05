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
    //private Text NameOfPlayer;
    //private Text IdOfPlayer;


    [Header("effects")]
    public GameObject salveEffect;
    public GameObject shieldEffect;
    public AudioClip[] soundStep;
    public GameObject soundSalve;
    public GameObject soundShield;
    public GameObject soundKey;
    public GameObject soundDoor;




    //   public GameObject soundHit2;
    private AudioSource audioSource;

    public GameObject shield;

    [Header("controls")]
    public float speed;
    public int health;

    public Bonus shieldTimer;
    private int score;
    [Header("Text")]
    public Text textScore;
    public Text healthDisplay;
    //   public Text scoreDisplayPause;
    //  public Text scoreDisplayGame;
    //   public Text scoreDisplayDeath;
    public Text DisplayName;
    public GameObject PanelDeath;


    //public Text DisplayID;
    [Header("Key")]
    public GameObject keyIcon;
    public GameObject keyEffect;
    // public Text DisplayNamePause;

    private bool keyButtonPush;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //NameOfPlayer = GameObject.Find("NamePlayer").GetComponent<Text>();
        //IdOfPlayer = GameObject.Find("IdPlayer").GetComponent<Text>();
        healthDisplay.text = "" + health;

        // NameOfPlayer= FindSceneObjectsOfType(Restart)
        DisplayName.text = PlayerPrefs.GetString("playerName");
        //  textScore.text = PlayerPrefs.GetInt("Score").ToString();
        //DisplayName.text = NameOfPlayer.text;
        //DisplayID.text = IdOfPlayer.text;
        // DisplayNameDeath.text = "" + NameOfPlayer.text;

    }
    private void Update()
    {
        if (health >= 20)
        {
            health = 20;
            healthDisplay.text = "" + health;

        }
        if (!shield.activeInHierarchy)
        {
            speed = 8;
        }
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        PlayerPrefs.SetInt("Score", score);
        //if (!PlayerPrefs.HasKey("playerName"))
        //{
        //    PlayerPrefs.SetString("playerName", "NoName");
        //}

        //else
        //{
        //    DisplayName.text = PlayerPrefs.GetString("playerName");
        //}
        // DisplayName.text = NameOfPlayer.ToString();
    }
    private void FixedUpdate()
    {
        //  PlayerPrefs.SetInt("Score", score);
        //  PlayerPrefs.SetString("Player", name);
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

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Flip()
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
                speed = 5;
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

    //public void OnKeyButtonDown()
    //{
        
    //    keyButtonPush = !keyButtonPush;
    //}
    private void OnTriggerStay2D(Collider2D other)
    {
        //if (Input.GetKey(KeyCode.E))
        //{
        //    OnKeyButtonDown();
        //}//&& keyButtonPush
        if (other.CompareTag("Door") && keyIcon.activeInHierarchy)
        {
            Instantiate(keyEffect, other.transform.position, Quaternion.identity);
            keyIcon.SetActive(false);
            other.gameObject.SetActive(false);
            //  keyButtonPush = false;
            Instantiate(soundDoor, transform.position, Quaternion.identity);

        }
        if (other.CompareTag("Exit"))
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
            PanelDeath.SetActive(true);
        }
    }
    public void ChangeHealth(int healthValue)
    {
        if (!shield.activeInHierarchy || shield.activeInHierarchy&& healthValue>0)
        {
            health += healthValue;
            healthDisplay.text = "" + health;
        }
        else if (shield.activeInHierarchy && healthValue < 0)
        {
            shieldTimer.ReduseTime(healthValue);
        }

        //   scoreDisplay.text = "" + score;
    }
    public void Kill()
    {
         score++;
        textScore.text = PlayerPrefs.GetInt("Score").ToString();
       

    }


}
