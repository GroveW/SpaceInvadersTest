using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private static EnemiesSwarm swarm;

    private void Start()
    {
        if (!swarm)
            swarm = GetComponentInParent<EnemiesSwarm>();
    }

    public virtual void Upgrade() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Instance.AddPoint();
            swarm.UpgradeSpeed();
            Upgrade();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
