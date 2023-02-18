using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frog;
    private Animator _anim;
    public float PixelsHorizontal;
    public float PixelsVertical;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Move()
    {
        _anim.SetBool("IsMoving", false);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frog.position += Vector2.left * PixelsHorizontal;
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("MoveX", -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _frog.position += Vector2.right * PixelsHorizontal;
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("MoveX", 1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _frog.position += Vector2.up * PixelsVertical;
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("MoveY", 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _frog.position += Vector2.down * PixelsVertical;
            _anim.SetBool("IsMoving", true);
            _anim.SetFloat("MoveY", -1);
        }
    }
    private void Update()
    {
        Move();
    }

}
