using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public bool isRight;
    void Update()
    {
        if (isRight)
        {
            transform.position += Vector3.right * (Random.Range(3, 10) * Time.deltaTime);
        }
        else
        {
            transform.position += Vector3.left * (Random.Range(3, 10) * Time.deltaTime);
        }
    }
}
