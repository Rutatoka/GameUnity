using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunType gunType;
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public Transform[] shotPoints;

    private float timeBtfShoths;
    public float StartTimeBtfShoths;
    private Player player;
    private float rotZ;
    private Vector3 difference;
    //  public GameObject soundShoot;
    public GameObject soundBow;
    private AudioSource audioSource;
    private Animator anim;


    public enum GunType { Default, Enemy,Boss }

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update()
    {
       
        if (gunType == GunType.Default)
        {            
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
          //  transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else if (gunType == GunType.Enemy)
        {
             difference = player.transform.position -transform.position ;
             rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
          //  transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else if (gunType == GunType.Boss)
        {
           // Vector3 globalVelocity = new Vector3(1, 1, 0);
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
          //  transform.Translate(globalVelocity);

        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtfShoths<=0)
        {
            if (Input.GetMouseButton(0) || gunType == GunType.Enemy)
            {
                Shoot();
                anim.SetBool("isAtack", true);
            }
            if ( gunType == GunType.Boss)
            {
                ShootBoss();
            }
            if (!Input.GetMouseButton(0))
            {
                anim.SetBool("isAtack", false);
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
    public void ShootBoss()
    {
        //int rand = Random.Range(0, 4);
        for (int i = 0; i < shotPoints.Length; i++)
        {
            Instantiate(bullet, shotPoints[i].position, shotPoints[i].rotation);
        }
        //   int lenght = shotPoints.Length;
        Instantiate(soundBow, transform.position, Quaternion.identity);
   //     Instantiate(bullet, shotPoints[rand].position, shotPoints[rand].rotation);
        timeBtfShoths = StartTimeBtfShoths+1f;
    }
}
