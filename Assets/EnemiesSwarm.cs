using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSwarm : MonoBehaviour
{
    [SerializeField]
    private float moveStep = 0.1f;

    [SerializeField]
    private float moveInterval = 1.0f;
    private float moveStamp = 0.0f;

    private int direction = -1;
    private bool moveDown = false;

    [SerializeField]
    private int enemiesColumns = 8;

    [SerializeField]
    private int enemiesRows = 4;

    [SerializeField]
    private GameObject rammingEnemy;

    void Start()
    {
        float distanceBetween = 0.5f;

        for (int r = 0; r < enemiesRows; r++)
        {
            for (int c = 0; c < enemiesColumns; c++)
            {
                Instantiate(rammingEnemy, new Vector3(c * distanceBetween - 1.5f, -r * distanceBetween + 3.0f, transform.position.z), Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {
        if (Time.time - moveStamp >= moveInterval)
        {
            moveStamp = Time.time;

            if (!moveDown)
                transform.Translate(Vector3.right * direction * moveStep);
            else
            {
                transform.Translate(Vector3.down * moveStep);
                moveDown = false;
            }
        }
    }

    public void Turn()
    {
        direction *= -1;
        moveDown = true;
    }

    public void UpgradeSpeed()
    {
        moveInterval -= 0.025f;

        if (moveInterval < 0.1f)
            moveInterval = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightEdge") && direction == 1)
        {
            Turn();
        }
        else if (collision.CompareTag("LeftEdge") && direction == -1)
        {
            Turn();
        }
    }
}
