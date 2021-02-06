using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Instance.AddPoint();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
