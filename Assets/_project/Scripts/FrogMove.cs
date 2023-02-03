using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frog;
    public float PixelsHorizontal;
    public float PixelsVertical;
  
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frog.position += Vector2.left * PixelsHorizontal;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _frog.position += Vector2.right * PixelsHorizontal;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _frog.position += Vector2.up * PixelsVertical;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _frog.position += Vector2.down * PixelsVertical;
        }
        return;
    }
    private void Update()
    {
        Move();
    }

}
