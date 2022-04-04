using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LiderTable : MonoBehaviour
{
    private int i;
    private Restart restart;

    private void Start()
    {
        restart = GameObject.FindGameObjectWithTag("deathPlayer").GetComponent<Restart>();
    }
    private void Update()
    {
            if(transform.childCount <= 0)
        {
            restart.isFull[i] = false;
        }
    }
}
