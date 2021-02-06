using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;

    private Rigidbody2D rb;

    private int direction = 0;

    [SerializeField]
    private float fireInterval = 2.0f;
    private float fireStamp = 0.0f;

    [SerializeField]
    private GameObject bullet;

    private float bulletSpeed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time - fireStamp >= fireInterval)
        {
            fireStamp = Time.time;

            Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
        }
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
