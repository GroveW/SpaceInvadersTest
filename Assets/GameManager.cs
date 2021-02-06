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
        float pixelHeight = Camera.main.pixelHeight;
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;
        float buttonsAndTextAreaRatio = (btnRect.sizeDelta.y + txtRect.sizeDelta.y) / pixelHeight;

        float boardHeight = 1.0f - buttonsAndTextAreaRatio;

        board.transform.localScale = new Vector3(4.7f, height * boardHeight, board.transform.localScale.z);
    }

    public void AddPoint()
    {
        Score += 1;
    }
}
