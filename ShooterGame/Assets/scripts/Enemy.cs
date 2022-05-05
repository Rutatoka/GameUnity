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
    public GameObject soundHitHero;
    public GameObject soundDieGhost;
    public GameObject soundDieGrib;



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
            if (gameObject.CompareTag("EnemyGrib"))
            {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
                Instantiate(soundDieGrib, transform.position, Quaternion.identity);

                player.Kill();
            }
            else if (gameObject.CompareTag("EnemyGhost"))
            {
                Destroy(gameObject);
                room.enemies.Remove(gameObject);
                Instantiate(soundDieGhost, transform.position, Quaternion.identity);

                player.Kill();
            }


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
       // int rand = Random.Range(0, soundHitHero.Length);
        Instantiate(soundHitHero, transform.position, Quaternion.identity);

        player.healthDisplay.text = ""+player.health;
        timeBtwAtack = startTimeBtwAtack;
    }

}
