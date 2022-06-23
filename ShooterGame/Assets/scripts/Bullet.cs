using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    private Player player;
   public GameObject effect;
    public GameObject destroyEffect;
    //public AudioClip[] soundHitsHero;
    //public AudioClip[] soundHitsEnemy;
    public GameObject[] soundHitHero;
    //private AudioSource audioSource;
    [SerializeField] bool enemyBullet;
    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("EnemyGrib")|| hitInfo.collider.CompareTag("EnemyGhost"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            
                Instantiate(effect, transform.position, Quaternion.identity);
                DestroyBullet();
            }
            if ( hitInfo.collider.CompareTag("Boss"))
            {             
                hitInfo.collider.GetComponent<Boss>().TakeDamage(damage);
                Instantiate(effect, transform.position, Quaternion.identity);
                DestroyBullet();
            }
            if (hitInfo.collider.CompareTag("falls"))
            {              
                Instantiate(effect, transform.position, Quaternion.identity);
                DestroyBullet();
            }
            if (hitInfo.collider.CompareTag("Player") && enemyBullet)
            {           
                hitInfo.collider.GetComponent<Player>().ChangeHealth(-damage);
                Instantiate(effect, transform.position, Quaternion.identity);
                int rand = Random.Range(0, soundHitHero.Length);
                Instantiate(soundHitHero[rand], transform.position, Quaternion.identity);
                DestroyBullet();
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    } 
    public void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
