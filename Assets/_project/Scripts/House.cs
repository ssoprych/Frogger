using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public bool Visited;
    public Sprite[] Houses;
    public SpriteRenderer spriterenderer;
    private static int i = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            if (Visited == false)
            {
                GameManager.Instance.touchedHouse = true;
                Visited = true;
                spriterenderer.sprite = Houses[i];
            }
        }
    }
}
