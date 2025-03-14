using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [Header("Hands to Display")]
    [SerializeField] private HandController upLeft;
    [SerializeField] private HandController downLeft;
    [SerializeField] private HandController upRight;
    [SerializeField] private HandController downRight;

    [Header("Colors to Display")]
    [SerializeField] private ColorDisplayedController red;
    [SerializeField] private ColorDisplayedController yellow;
    [SerializeField] private ColorDisplayedController blue;
    [SerializeField] private ColorDisplayedController green;

    public static DisplayManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }

    public void DisplayClickedColor(GameManager.Colors clickedColor)
    {
        ColorDisplayedController color = clickedColor switch
        {
            GameManager.Colors.Red => red,
            GameManager.Colors.Blue => blue,
            GameManager.Colors.Yellow => yellow,
            GameManager.Colors.Green => green,
            _ => throw new ArgumentOutOfRangeException(nameof(clickedColor), clickedColor, null)
        };
        color.Grow();
    }

    public void DisplayHandAt(GameManager.Colors wantedColor)
    {
        HandController hand = wantedColor switch
        {
            GameManager.Colors.Red => downLeft,
            GameManager.Colors.Blue => upRight,
            GameManager.Colors.Yellow => upLeft,
            GameManager.Colors.Green => downRight,
            _ => throw new ArgumentOutOfRangeException(nameof(wantedColor), wantedColor, null)
        };
        hand.HandClick();
    }
}
