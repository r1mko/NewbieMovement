using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    private Transform playerTransform;
    [SerializeField] private AudioSource movementSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movementSound.Play();           
        }

       /* if (rb2d.velocity != Vector2.zero)
        {
            movementSound.Play();
        }*/
    }

    void FixedUpdate()
    {


        if (rb2d.velocity == Vector2.zero)
        {
            playerTransform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb2d.velocity = new Vector2(0f, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb2d.velocity = new Vector2(0f, -speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                rb2d.velocity = new Vector2(-speed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                rb2d.velocity = new Vector2(speed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
    }
}
