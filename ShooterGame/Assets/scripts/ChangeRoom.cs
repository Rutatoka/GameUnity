using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
public Vector3 cameraPos;
  public Vector3 playerPos;
  ////  public Vector3 cameraDal;
    private float camSpeed = 0.5f;
    public float camSize;
    private float time;

    //  public V

    private Camera cam;
    private void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           other.transform.position += playerPos;
            cam.transform.position += cameraPos;
            time = 0;
            while (time < 1f)
            {
                time += camSpeed * Time.deltaTime;
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize, time);
            }
            cam.orthographicSize = camSize;

        }
    }
}
