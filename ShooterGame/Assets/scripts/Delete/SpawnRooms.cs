using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
//    public Direction direction;
//    public enum Direction
//    {
//        top,
//        bottom,
//        left,
//        right,
//        none
//    }
//    private VariableRooms variants;
//    private int rand;
//    private bool spawned = false;
//    private float waitTime = 3f;
//    // Start is called before the first frame update
//    void Start()
//    {
//        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<VariableRooms>();
//        Destroy(gameObject, waitTime);
//        Invoke("Spawn", 0.2f);
//    }

//    // Update is called once per frame
//    public void Spawn()
//    {
//        if (!spawned)
//        {
//            if (direction == Direction.top)
//            {
//                rand = Random.Range(0,variants.topRooms.Length);
//                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
//            }
//            else if (direction == Direction.bottom)
//            {
//                rand = Random.Range(0, variants.bottomRooms.Length);
//                Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);

//            }
//           else if (direction == Direction.left)
//            {
//                rand = Random.Range(0, variants.leftRooms.Length);
//                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);

//            }
//           else if (direction == Direction.right)
//            {
//                rand = Random.Range(0, variants.rightRooms.Length);
//                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);

//            }
//            spawned = true;
//        }
//    }

//    private void OnTriggerStay2D(Collider2D other)
//    {
//        if (other.CompareTag("RoomPoint")&& other.GetComponent<SpawnRooms>().spawned)
//        {
//            Destroy(gameObject);
//        }
//    }
}
