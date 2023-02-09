using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject Car;
    public Transform SpawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Instantiate(Car, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }
}
