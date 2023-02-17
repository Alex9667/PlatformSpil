using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Enemy;
    public float Speed;
    private float moveSpeed;
    private Rigidbody2D rb;

    private Quaternion stopRotating;

    private Quaternion moveLeft;

    private Quaternion moveRight;

    private float direction;
    private float minX;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        stopRotating.z = 0f;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 1;
        moveLeft.y = 180f;
        moveLeft.z = 0f;
        moveRight.y = 0f;
        moveRight.z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        stopRotating.y = direction;
        Enemy.transform.rotation= stopRotating;

        rb.velocity = new Vector2(Speed * moveSpeed, rb.velocity.y);
        if (rb.position.x >= maxX)
        {
            Enemy.transform.rotation = moveLeft;
            direction = -180f;
            moveSpeed = -1;
        }
        if (rb.position.x <= minX)
        {
            Enemy.transform.rotation = moveRight;
            direction = 0f;
            moveSpeed = 1;
        }
    }
}
