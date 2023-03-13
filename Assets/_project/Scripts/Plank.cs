using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public bool isRight;
    public int Speed;
    private void Start()
    {
        Speed = Random.Range(3,6);
        if (GameManager.Instance.HousesVisited == 1)
        {
            Speed = Random.Range(4, 8);
        }
        if( GameManager.Instance.HousesVisited == 2)
        {
            Speed = Random.Range(5, 10);
        }
    }

    void Update()
    {
        if (isRight)
        {
            transform.position += Vector3.right * (Speed * Time.deltaTime);
        }
        else
        {
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }

    }
}
