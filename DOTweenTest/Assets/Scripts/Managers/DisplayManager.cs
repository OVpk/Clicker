using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Shop")] 
    
    [SerializeField] private Image[] itemDisplayers;
    [SerializeField] private TMP_Text[] priceDisplayers;

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

    public void DisplayClickedColor(ColorZoneData.Colors clickedColor)
    {
        ColorDisplayedController color = clickedColor switch
        {
            ColorZoneData.Colors.Red => red,
            ColorZoneData.Colors.Blue => blue,
            ColorZoneData.Colors.Yellow => yellow,
            ColorZoneData.Colors.Green => green,
            _ => throw new ArgumentOutOfRangeException(nameof(clickedColor), clickedColor, null)
        };
        color.Grow();
    }

    public void DisplayHandAt(ColorZoneData.Colors wantedColor)
    {
        HandController hand = wantedColor switch
        {
            ColorZoneData.Colors.Red => downLeft,
            ColorZoneData.Colors.Blue => upRight,
            ColorZoneData.Colors.Yellow => upLeft,
            ColorZoneData.Colors.Green => downRight,
            _ => throw new ArgumentOutOfRangeException(nameof(wantedColor), wantedColor, null)
        };
        hand.HandClick();
    }

    public void UpdateDisplayedShopItems()
    {
        for (int i = 0; i < itemDisplayers.Length; i++)
        {
            if (GameManager.Instance.upgrades[i] != null)
            {
                itemDisplayers[i].sprite = GameManager.Instance.upgrades[i].sprite;
                priceDisplayers[i].text = GameManager.Instance.upgrades[i].price.ToString();
            }
        }
    }
}
