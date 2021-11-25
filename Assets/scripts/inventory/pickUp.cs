using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private inventory Inventory;
    public GameObject slotButton;

    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for ( int i=0; i<Inventory.slots.Length;i++)
            {
                if (Inventory.isFull[i]==false)
                {
                    Inventory.isFull[i] = true;
                    Instantiate(slotButton, Inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
