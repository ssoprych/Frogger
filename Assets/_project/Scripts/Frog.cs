using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frog;
    private Animator _anim;
    public float PixelsHorizontal;
    public float PixelsVertical;
    public GameObject DeathEffect;
    public Transform FrogStartingPoint;
    public bool HealthReduced = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

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
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frog.position += Vector2.left * PixelsHorizontal;
            _anim.SetBool("IsLeft", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _frog.position += Vector2.right * PixelsHorizontal;
            _anim.SetBool("IsRight", true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _frog.position += Vector2.down * PixelsVertical;
            _anim.SetBool("IsDown", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthReduced = false;
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
            Instantiate(DeathEffect, transform.position, transform.rotation);
            GameManager.Instance.Health--;
            transform.position = new Vector2(FrogStartingPoint.position.x, FrogStartingPoint.position.y);
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
        if (GameManager.Instance.onPlank == false && GameManager.Instance.onWater == true)
        {
            if (HealthReduced == false)
            {
                Instantiate(DeathEffect, transform.position, transform.rotation);
                GameManager.Instance.Health--;
                transform.position = new Vector2(FrogStartingPoint.position.x, FrogStartingPoint.position.y);
                HealthReduced = true;
            }
        }

        if (GameManager.Instance.Health == 0)
        {
            Destroy(gameObject);
        }
        
    }

}