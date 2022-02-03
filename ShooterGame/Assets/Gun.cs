using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtfShoths;
    public float StartTimeBtfShoths;
   

   
    void Update()
    {
       
        Vector3 difference =Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtfShoths<=0)
        {
            if (Input.GetMouseButton(0))
            {
              
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtfShoths = StartTimeBtfShoths;
            }
         
        }
     else
           {
                timeBtfShoths -= Time.deltaTime;
           }
    
    }
}
