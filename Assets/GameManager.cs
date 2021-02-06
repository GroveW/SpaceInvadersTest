using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject board;

    [SerializeField]
    private RectTransform btnRect;

    [SerializeField]
    private RectTransform txtRect;

    void Start()
    {
        float pixelHeight = Camera.main.pixelHeight;
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;
        float buttonsAndTextAreaRatio = (btnRect.sizeDelta.y + txtRect.sizeDelta.y) / pixelHeight;

        float boardHeight = 1.0f - buttonsAndTextAreaRatio;

        board.transform.localScale = new Vector3(4.5f, height * boardHeight, board.transform.localScale.z);
    }

    void Update()
    {
        
    }
}
