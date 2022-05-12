using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    //  public float endX;
    //  public float startX;
    public float speed;

    private void Awake()
    {
        this.transform.position = new Vector3()
        {
            x = this.player.transform.position.x,
            y = this.player.transform.position.y,
            z = this.player.transform.position.z-10
        }; 
    }
    private void Update()
    {
        if (this.player.transform)
        {
            Vector3 target = new Vector3()
            {
                x = this.player.transform.position.x,
                y = this.player.transform.position.y,
                z = this.player.transform.position.z - 10
            };
            Vector3 pos = Vector3.Lerp(transform.position, target, this.speed*Time.deltaTime);
            this.transform.position = pos;
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        //if (transform.position.x <= endX)
        //{
        //    Vector2 pos = new Vector2(startX, transform.position.y);
        //    transform.position = pos;
        //}
    }

}
