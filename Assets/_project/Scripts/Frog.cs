using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frog;
    private Animator _anim;
    public float PixelsHorizontal;
    public float PixelsVertical;
    //public Vector2 direction;
    //public RaycastHit2D hit;
    

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    //Raycasty wyrzucaja nulla i w ogole jakos zly dystans jest i niedoklanie to sie mierzy

    //private RaycastHit2D CheckRaycast(Vector2 direction)
    //{
    // Vector2 startingPosition = new Vector2(transform.position.x, transform.position.y);
    // Debug.DrawRay(startingPosition, direction, Color.red);
    // return Physics2D.Raycast(startingPosition, direction, 1);
    //}
    void Move()
    {
        _anim.SetBool("IsDown", false);
        _anim.SetBool("IsUp", false);
        _anim.SetBool("IsLeft", false);
        _anim.SetBool("IsRight", false);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _frog.position += Vector2.up * PixelsVertical;
            _anim.SetBool("IsUp", true);
            //direction = new Vector2(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frog.position += Vector2.left * PixelsHorizontal;
            _anim.SetBool("IsLeft", true);
            //direction = new Vector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _frog.position += Vector2.right * PixelsHorizontal;
            _anim.SetBool("IsRight", true);
            //direction = new Vector2(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _frog.position += Vector2.down * PixelsVertical;
            _anim.SetBool("IsDown", true);
            //direction = new Vector2(0, -1);
        }
    }

    //private bool RaycastCheckUpdate()
    //{
    // if (_anim.GetBool("IsUp") || _anim.GetBool("IsDown") || _anim.GetBool("IsRight") || _anim.GetBool("IsLeft"))
    //{
    // RaycastHit2D hit = CheckRaycast(direction);
    // if (hit.collider.gameObject.CompareTag("Water") || hit.collider.gameObject.CompareTag("Car"))
    // {
    //Debug.Log("Lose");
    //}
    //return true;
    //}
    // else
    // {
    //  return false;
    //}
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plank"))
        {
            GameManager.Instance.onPlank = true;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.Instance.onWater = true;
        }
        if (collision.gameObject.CompareTag("Car"))
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plank"))
        {
            GameManager.Instance.onPlank = false;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.Instance.onWater = false;
        }
    }
    private void Update()
    {
        Move();
        //RaycastCheckUpdate();
        if (GameManager.Instance.onPlank == false && GameManager.Instance.onWater == true)
        {
            Time.timeScale = 0;
        }
        
    }

}
