using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector3 cameraPos;
    public Vector3 playerPos;
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
        }
    }
}
