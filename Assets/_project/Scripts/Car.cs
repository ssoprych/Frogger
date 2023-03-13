using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int Speed;
    public bool isRight;

    private void Start()
    {
        Speed = Random.Range(6, 8);
        if (GameManager.Instance.HousesVisited == 1)
        {
            Speed = Random.Range(9, 11);
        }
        if (GameManager.Instance.HousesVisited == 2)
        {
            Speed = Random.Range(12, 13);
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
