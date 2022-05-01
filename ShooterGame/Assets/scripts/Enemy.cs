using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public GameObject floatingDamage;
    public int health;
    public float speed;
    private Rigidbody2D rb;
    public float timeBtwAtack;
    public float startTimeBtwAtack;
    public int damage;
    private Animator anim;
    private Player player;
    private float stopTime;
    private AddRoom room;
    public float startStopTime;
    public float normalspeed;
   public GameObject effect1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        room = GetComponentInParent<AddRoom>();
     
    }
    private void Update()

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
            room.enemies.Remove(gameObject);
            player.Kill();
           
            // player.scoreDisplayGame.text = "" + player.score;
           // PlayerPrefs.SetInt("Score", score);
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

       if(player.transform.position.y != transform.position.y)
        {
            transform.position = player.transform.position;
        }
        //  Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        transform.position = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.deltaTime);
      

    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;  
        health -= damage;
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 2.75f);
        Instantiate(floatingDamage, damagePos, Quaternion.identity);
        floatingDamage.GetComponentInChildren<FloatingDamaeg>().damage = damage;
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
