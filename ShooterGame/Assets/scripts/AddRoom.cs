using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [Header("Walls")]
    public GameObject[] walls;
    public GameObject wallEffect;
    public GameObject door;
    public GameObject soundDoor;

    [Header("Enemies")]
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;
    [Header("Powerups")]
    public GameObject shield;
    public GameObject healthPotion;

    [HideInInspector] public List<GameObject> enemies;
    private VariableRooms variants;
    private bool spawned;
    private bool wallDestroyed;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<VariableRooms>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&!spawned)
        {
            spawned = true;

            foreach (Transform spawner in enemySpawners)
            {
                int rand = Random.Range(0, 11);
                if (rand<9)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
                //else if (rand == 7)
                //{

                //}
                //else if (rand == 8)
                //{

                //}
                else if (rand == 9)
                {
                    Instantiate(healthPotion, spawner.position, Quaternion.identity);

                }
                else if (rand == 10)
                {
                    Instantiate(shield, spawner.position, Quaternion.identity);

                }
            }
            StartCoroutine(CheckEnemies());
        }
            
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        DestroyWalls();
    }
    public void DestroyWalls()
    {
        foreach (GameObject wall in walls)
        {
            if (wall != null && wall.transform.childCount!=0)
            {
                Instantiate(wallEffect, wall.transform.position, Quaternion.identity);
                Instantiate(soundDoor, transform.position, Quaternion.identity);

                Destroy(wall);

            }
        }
        wallDestroyed = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (wallDestroyed && other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }
    }
}
