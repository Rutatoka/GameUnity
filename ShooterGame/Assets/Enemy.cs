using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    public float timeBtwAtack;
    public float startTimeBtwAtack;
    public int damage;
    private Animator anim;
    private Player player;
    private float stopTime;
    public float startStopTime;
    public float normalspeed;
   public GameObject effect1;
 

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
      

    }
    private void FixedUpdate()

    {

        if (stopTime<=0)
        {
            speed = normalspeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        { 
          
            Destroy(gameObject);
            player.Kill();
            player.scoreDisplay.text = "" + player.score;
           
            //  Instantiate(effect1, transform.position , Quaternion.identity);


        }
        if (player.transform.position.x >transform.position.x)
        {
          transform.eulerAngles = new Vector3(0, 180, 0);
      }
      
     else
       {
          transform.eulerAngles = new Vector3(0, 0, 0);

       }
       //  Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed*Time.fixedDeltaTime);
     //   transform.forward = player.transform.position;

    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;  
        health -= damage;
      //  Instantiate(effect1, transform.position, Quaternion.identity);
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAtack<=0)
            {
                anim.SetTrigger("attackEnemy");
            }
            else
            {
                timeBtwAtack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack() {
    Instantiate(effect1, player.transform.position, Quaternion.identity);
        player.health -= damage;
        player.healthDisplay.text = ""+player.health;
        timeBtwAtack = startTimeBtwAtack;
    }

}
