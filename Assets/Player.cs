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

    [SerializeField]
    private float bulletSpeed = 2.0f;

    private bool isGameEnded = false;

    [SerializeField]
    private int boostDuration = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGameEnded)
            return;

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
        if (isGameEnded)
            return;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.TakePoint();
            Destroy(collision.gameObject);
        }
    }

    public void GameEnded()
    {
        isGameEnded = true;
    }

    public void StartBoost()
    {
        fireInterval /= 2.0f;
        StartCoroutine(HandleBoost());
    }

    private IEnumerator HandleBoost()
    {
        yield return new WaitForSecondsRealtime(boostDuration);
        fireInterval *= 2.0f;
        GameManager.Instance.DisableBoost();
    }
}
