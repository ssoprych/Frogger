using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Plank;
    public Transform SpawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plank"))
        {
            Instantiate(Plank, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }
}
