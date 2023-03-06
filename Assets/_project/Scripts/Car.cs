using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int Speed;
    public bool isRight;

    private void Start()
    {
        Speed = Random.Range(10, 13);
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
