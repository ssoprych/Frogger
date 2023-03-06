using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public bool Visited;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            if (Visited == false)
            {
                GameManager.Instance.touchedHouse = true;
                Visited = true;
            }
        }
    }
}
