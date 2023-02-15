using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float FallMultiplier = 2.5f;

    public float LowJumpMultiplier = 2f;



    public float Speed;

    private float move;

    private AudioSource jumpSound;

    public float Jump;

    public bool IsJumping;

    public GameObject Player;

    private float temp;

    private Quaternion stopRotating;

    private Quaternion moveLeft;

    private Quaternion moveRight;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        stopRotating.z = 0f;
        moveLeft.y = -180f; moveLeft.z = 0f; moveRight.y = 0f; moveRight.z = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stopRotating.y = temp;


        Player.transform.rotation = stopRotating;

        move = Input.GetAxis("Horizontal");
        if (move < 0f)
        {
            Player.transform.rotation = moveLeft;
            temp = -180f;
        }
        else if (move > 0f)
        {
            Player.transform.rotation = moveRight;
            temp = 0f;
        }
        else if (move == 0f)
        {

        }
        rb.velocity = new Vector2(Speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsJumping == false)
        {
           rb.AddForce(new Vector2(rb.velocity.x, Jump));
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            jumpSound.Play(0);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}
