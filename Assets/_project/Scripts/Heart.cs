using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (GameManager.Instance.Health > numOfHearts)
            {
                GameManager.Instance.Health = numOfHearts;
            }

            if (i < GameManager.Instance.Health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
