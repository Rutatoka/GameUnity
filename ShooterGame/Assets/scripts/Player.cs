using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;

    public float speed;
    public int health;
    private Animator anim;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public Text healthDisplay;
    public int score;
    public Text scoreDisplayPause;
    public Text scoreDisplayGame;
    public Text scoreDisplayDeath;
    public GameObject Panel;
    private Text NameOfPlayer;
    public Text DisplayNameGame;
    public Text DisplayNameDeath;
    public Text DisplayNamePause;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
         NameOfPlayer = GameObject.Find("NamePlayer").GetComponent<Text>();
        // NameOfPlayer= FindSceneObjectsOfType(Restart)

        DisplayNameGame.text = "" + NameOfPlayer.text;
        DisplayNamePause.text = "" + NameOfPlayer.text;
        DisplayNameDeath.text = "" + NameOfPlayer.text;

    }
    private void Update()
    {

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
       // DisplayName.text = NameOfPlayer.ToString();
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
            Panel.SetActive(true);
            Destroy(gameObject);
           
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Flip()
    {
        //facingRight = !facingRight;
        //Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
    public void ChangeHealth(int healthValue)
    {
       health += healthValue;
     healthDisplay.text = "" + health;
     //   scoreDisplay.text = "" + score;
    }
    public void Kill()
    {
        score++;
    }
}
