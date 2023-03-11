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
        _frog = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        //set all animations bools to false
        _anim.SetBool("IsDown", false);
        _anim.SetBool("IsUp", false);
        _anim.SetBool("IsLeft", false);
        _anim.SetBool("IsRight", false);

        //move in certain direction, play move animation and disable Plank component and isRight bool so if frog stands on left plank it will move left instead of right
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _frog.position += Vector2.up * PixelsVertical;
            _anim.SetBool("IsUp", true);
            GetComponent<Plank>().enabled = false;
            GetComponent<Plank>().isRight = false;
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
            GetComponent<Plank>().enabled = false;
            GetComponent<Plank>().isRight = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        HealthReduced = false;
        if (collision.gameObject.CompareTag("Plank"))
        {
            GameManager.Instance.onPlank = true;
            //equals the speed of frog and the plank
            GetComponent<Plank>().Speed = collision.GetComponent<Plank>().Speed;
            //Actives the plank script attached to frog gameObject so it moves with plank
            GetComponent<Plank>().enabled = true;
            //If the plank is moving to right frog will also move that way
            if (collision.GetComponent<Plank>().isRight)
            {
                GetComponent<Plank>().isRight = true;
            }
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
            GetComponent<Plank>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.Instance.onWater = false;
        }
    }

    private void Update()
    {
        Move();
        //dying to water 
        if (GameManager.Instance.onPlank == false && GameManager.Instance.onWater == true)
        {
            if (HealthReduced == false)
            {
                Instantiate(DeathEffect, transform.position, transform.rotation);
                transform.SetParent(null);
                GameManager.Instance.Health--;
                transform.position = new Vector2(FrogStartingPoint.position.x, FrogStartingPoint.position.y);
                HealthReduced = true;
            }
        }

        //screen boundaries
        if (GameManager.Instance.OutOfScreen)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            GameManager.Instance.Health--;
            transform.position = new Vector2(FrogStartingPoint.position.x, FrogStartingPoint.position.y);
            GameManager.Instance.OutOfScreen = false;
        }

        //scoring point by going into one of the house
        if (GameManager.Instance.touchedHouse)
        {
            transform.position = new Vector2(FrogStartingPoint.position.x, FrogStartingPoint.position.y);
            GameManager.Instance.Score++;
            GameManager.Instance.touchedHouse = false;
        }

        //Ending game
        if (GameManager.Instance.Health == 0 || GameManager.Instance.Score == 3)
        {
            Destroy(gameObject);
        }

    }

}
