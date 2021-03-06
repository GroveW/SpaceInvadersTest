using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private static EnemiesSwarm swarm;

    protected int column;
    protected int row;

    public int Column { get => column; }

    private static int enemiesLeft;

    protected static int[] activeRow;
    private static int[,] deadUfos;

    protected void Start()
    {
        int columns = GameManager.Instance.EnemiesColumns;
        int rows = GameManager.Instance.EnemiesRows;

        enemiesLeft = columns * rows;
        activeRow = new int[columns];
        deadUfos = new int[columns, rows];

        for (int i = 0; i < activeRow.Length; i++)
        {
            activeRow[i] = 3;
        }

        if (!swarm)
            swarm = GetComponentInParent<EnemiesSwarm>();
    }

    public abstract void Upgrade();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Instance.AddPointAndReduceColumn(column);
            swarm.UpgradeSpeed();
            Upgrade();
            Destroy(collision.gameObject);
            DestroyEnemy();
        }
    }

    public void SetColRow(int c, int r)
    {
        column = c;
        row = r;
    }

    public void DestroyEnemy()
    {
        if (activeRow[column] == row)
        {
            FindNextActiveRow();
        }

        deadUfos[column, row] = 1;
        enemiesLeft--;

        if (enemiesLeft == 0)
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }

    private void FindNextActiveRow()
    {
        if (row == 0)
            return;

        int nextActiveRow = row - 1;

        while (deadUfos[column, nextActiveRow] == 1)
        {
            nextActiveRow--;

            if (nextActiveRow < 0)
                break;
        }

        activeRow[column] = nextActiveRow;
    }
}
