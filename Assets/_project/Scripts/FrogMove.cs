using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frog;
  
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frog.velocity += new Vector2(-10, 0);
        }
    }
    private void Update()
    {
        Move();
    }

}
