using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("CM vcam1").GetComponent<Animator>();
    }
    private void Update()

    {
        if (health <= 0)
        { 
          
            Destroy(gameObject);
            camAnim.SetTrigger("shake");
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    public void TakeDamage(int damage)
    {
     
        health -= damage;
    }
}
