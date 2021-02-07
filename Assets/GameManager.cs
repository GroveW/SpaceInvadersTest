using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject board;

    [SerializeField]
    private RectTransform btnRect;

    [SerializeField]
    private RectTransform txtRect;

    [SerializeField]
    private int enemiesColumns = 8;

    public int EnemiesColumns { get => enemiesColumns; }

    [SerializeField]
    private int enemiesRows = 4;

    public int EnemiesRows { get => enemiesRows; }

    [SerializeField]
    private int[] ufosInColumn;

    private static GameManager instance;

    public static GameManager Instance { 
        get
        { 
            if (!instance) 
                instance = FindObjectOfType<GameManager>(); 
            
            return instance; 
        } 
        
        set => instance = value; 
    }

    [SerializeField]
    private Text scoreText;

    private int score;

    private int Score
    {
        get => score;

        set
        {
            score = value;
            scoreText.text = "Points: " + score;
        }
    }

    void Start()
    {
        ufosInColumn = new int[enemiesColumns];

        for (int i = 0; i < ufosInColumn.Length; i++)
        {
            ufosInColumn[i] = enemiesRows;
        }

        float pixelHeight = Camera.main.pixelHeight;
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;
        float buttonsAndTextAreaRatio = (btnRect.sizeDelta.y + txtRect.sizeDelta.y) / pixelHeight;

        float boardHeight = 1.0f - buttonsAndTextAreaRatio;

        board.transform.localScale = new Vector3(4.7f, height * boardHeight, board.transform.localScale.z);
    }

    public void AddPointAndReduceColumn(int column)
    {
        ufosInColumn[column]--;
        Score += 1;
    }

    public int GetColumnSize(int column)
    {
        return column >= 0 && column < ufosInColumn.Length ? ufosInColumn[column] : 0;
    }

    public void TakePointsFromRamming(int column)
    {
        Score -= ufosInColumn[column] * 2;
        ufosInColumn[column]--;
    }

    public void TakePoint()
    {
        Score -= 1;
    }
}
