using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    public GameObject floatingDamage;
   // public GameObject placeHealth;
    private int health;
    public int Maxhealth;
    public float speed;
    private Rigidbody2D rb;
    public float timeBtwAtack;
    public float startTimeBtwAtack;
    public int damage;
    private Animator anim;
    private Player player;
    private float stopTime;
    private AddRoom room;
    [HideInInspector] public bool playerNotInRoom;
   // private bool stopped;
    public float startStopTime;
  //  public float normalspeed;
    public GameObject effect1;
    public GameObject soundHitHero;
    public GameObject soundDieBoss;
   // public Health healthBar;
    public GameObject soundHiBoss;
    //public GameObject panelBoss;
    //public Slider slider;



    private void Start()
    {

        health = Maxhealth;
        //healthBar.SetHealth(health, Maxhealth);
        //  bar= GetComponent<Image>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        room = GetComponentInParent<AddRoom>();
   
    }
    private void Update()
    {
   
   
        if (health <= 0)
        {
            if (gameObject.CompareTag("Boss"))
            {
                Destroy(gameObject);
               room.enemies.Remove(gameObject);
                Instantiate(soundDieBoss, transform.position, Quaternion.identity);
                player.Kill();
            }
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (player.transform.position.y != transform.position.y)
        {
            transform.position = player.transform.position;
        }

        transform.position = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.deltaTime);



    }
    public void TakeDamage(int damage)
    {
  
        stopTime = startStopTime;
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 2.75f);
      //  Instantiate(panelBoss, damagePos, Quaternion.identity);
        health -= damage;
        //slider.value = health;
        //healthBar.SetHealth(health, Maxhealth);
        Instantiate(floatingDamage, damagePos, Quaternion.identity);
        floatingDamage.GetComponentInChildren<FloatingDamaeg>().damage = damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAtack <= 0)
            {
                anim.SetTrigger("BossAtack");
            }
            else
            {
                timeBtwAtack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {

        Instantiate(effect1, player.transform.position, Quaternion.identity);
        player.ChangeHealth(-damage);
        Instantiate(soundHitHero, transform.position, Quaternion.identity);
        player.healthDisplay.text = "" + player.health;
        timeBtwAtack = startTimeBtwAtack;
    }
    //public void ChangeHealthBoss(int health)
    //{
    //    slider.value = health;
    //}

}
