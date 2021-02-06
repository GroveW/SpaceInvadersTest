using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;

    private Rigidbody2D rb;

    private int direction = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction * moveSpeed, 0.0f);
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }
}
