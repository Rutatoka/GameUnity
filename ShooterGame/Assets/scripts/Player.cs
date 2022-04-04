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
    private Text NameOfPlayer;

    [Header("effects")]
    public GameObject salveEffect;
    public GameObject shieldEffect;

    public GameObject shield;

    [Header("controls")]
    public float speed;
    public int health;
 
    public Bonus shieldTimer;
    public int score;
    [Header("Text")] 
    public Text textScore;
    public Text healthDisplay;
 //   public Text scoreDisplayPause;
  //  public Text scoreDisplayGame;
 //   public Text scoreDisplayDeath;
    public Text DisplayName;
  //  public Text DisplayNameDeath;
   // public Text DisplayNamePause;
    public GameObject PanelDeath;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       //  NameOfPlayer = GameObject.Find("NamePlayer").GetComponent<Text>();
        // NameOfPlayer= FindSceneObjectsOfType(Restart)
     //   NameOfPlayer.text = PlayerPrefs.GetString("playerName");
      //  DisplayNameGame.text = "" + NameOfPlayer.text;
      //  DisplayNamePause.text = "" + NameOfPlayer.text;
      // DisplayNameDeath.text = "" + NameOfPlayer.text;

    }
    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        PlayerPrefs.SetInt("Score", score);
        if (!PlayerPrefs.HasKey("playerName"))
        {
            PlayerPrefs.SetString("playerName", "NoName");
        }

        else
        {
            DisplayName.text = PlayerPrefs.GetString("playerName");
        }
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
           if (moveInput.x==0)
       {
          anim.SetBool("isRunning", false);
       }
        
        else
     {
          anim.SetBool("isRunning", true);
      }

        if (health<=0)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Salve"))
        {
            ChangeHealth(5);
            Instantiate(salveEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Shield"))
        {
            if (!shield.activeInHierarchy)
            {
            shield.SetActive(true);
            shieldTimer.gameObject.SetActive(true);
            shieldTimer.isCooldown = true;
            Instantiate(shieldEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            }
            else
            {
                shieldTimer.ResetTimer();
                Destroy(other.gameObject);
            }

           
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
