using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    private static float minFireInterval = 4.0f;
    private static float maxFireInterval = 7.0f;
    private float fireStamp = 0.0f;
    private float fireInterval;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 2.0f;

    [SerializeField]
    private bool shootingEnabled = false;

    new private void Start()
    {
        base.Start();
        if (column == GameManager.Instance.EnemiesColumns)
            shootingEnabled = true;
        fireInterval = Random.Range(minFireInterval, maxFireInterval);
    }

    private void Update()
    {
        if (shootingEnabled && Time.time - fireStamp >= fireInterval)
        {
            fireStamp = Time.time;
            fireInterval = Random.Range(minFireInterval, maxFireInterval);

            Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
        }
        else if (!shootingEnabled && row == activeRow[column])
        {
            shootingEnabled = true;
        }
    }

    public override void Upgrade()
    {
        minFireInterval -= 0.03f;
        maxFireInterval -= 0.03f;
    }
}
