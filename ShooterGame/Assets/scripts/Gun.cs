using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunType gunType;
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtfShoths;
    public float StartTimeBtfShoths;
    private Player player;
    private float rotZ;
    private Vector3 difference;
    //  public GameObject soundShoot;
    public GameObject soundBow;
    private AudioSource audioSource;


    public enum GunType { Default, Enemy }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }
    void Update()
    {
       
      

        if (gunType == GunType.Default)
        {
            
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
           
        }
        else if (gunType == GunType.Enemy)
        {
             difference = player.transform.position -transform.position ;
             rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtfShoths<=0)
        {
            if (Input.GetMouseButton(0) || gunType == GunType.Enemy)
            {

                Shoot();
            }
        }
     else
           {
                timeBtfShoths -= Time.deltaTime;
           }
    }
    public void Shoot()
    {
        Instantiate(soundBow, transform.position, Quaternion.identity);

        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        timeBtfShoths = StartTimeBtfShoths;
    }
}
