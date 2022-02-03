using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;

    public float speed;
  
    private Animator anim;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator camAnim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        camAnim = GameObject.FindGameObjectWithTag("CM vcam1").GetComponent<Animator>();


    }
    private void Update()
    {
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
           if (moveInput.x==0)
       {
          anim.SetBool("isRunning", false);
       }
        
        else
     {
          anim.SetBool("isRunning", true);
      }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
