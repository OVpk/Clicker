using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [Header("Hands to Display")]
    [SerializeField] private HandDoTweenController upLeft;
    [SerializeField] private HandDoTweenController downLeft;
    [SerializeField] private HandDoTweenController upRight;
    [SerializeField] private HandDoTweenController downRight;

    [Header("Colors to Display")]
    [SerializeField] private ColorDoTweenController red;
    [SerializeField] private ColorDoTweenController yellow;
    [SerializeField] private ColorDoTweenController blue;
    [SerializeField] private ColorDoTweenController green;

    [Header("Displayers for actived upgrades")]
    [SerializeField] private SpriteRenderer[] redUpgrades;
    [SerializeField] private SpriteRenderer[] yellowUpgrades;
    [SerializeField] private SpriteRenderer[] blueUpgrades;
    [SerializeField] private SpriteRenderer[] greenUpgrades;

    [Header("Shop")] 
    [SerializeField] private ShopDoTweenController shop;
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
        UpdateDisplayedShopItems();
    }

    public void DisplayScore()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }

    public void DisplayClickedColor(ColorZoneData.Colors clickedColor)
    {
        ColorDoTweenController color = clickedColor switch
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
        HandDoTweenController hand = wantedColor switch
        {
            ColorZoneData.Colors.Red => downLeft,
            ColorZoneData.Colors.Blue => upRight,
            ColorZoneData.Colors.Yellow => upLeft,
            ColorZoneData.Colors.Green => downRight,
            _ => throw new ArgumentOutOfRangeException(nameof(wantedColor), wantedColor, null)
        };
        hand.HandClick();
    }
    
    public void DisplayShop(bool state)
    {
        shop.OpenCloseShop(state);
    }

    public void UpdateDisplayedShopItems()
    {
        for (int i = 0; i < GameManager.Instance.upgrades.Count && i < itemDisplayers.Length; i++)
        {
            itemDisplayers[i].sprite = GameManager.Instance.upgrades[i].sprite;
            priceDisplayers[i].text = GameManager.Instance.upgrades[i].price.ToString();
        }
    }

    public void DisplayActivedUpgrade(UpgradeData upgrade)
    {
        SpriteRenderer[] zoneToDisplay = upgrade.colorZone.color switch
        {
            ColorZoneData.Colors.Red => redUpgrades,
            ColorZoneData.Colors.Yellow => yellowUpgrades,
            ColorZoneData.Colors.Blue => blueUpgrades,
            ColorZoneData.Colors.Green => greenUpgrades,
            _ => throw new ArgumentOutOfRangeException()
        };
        for (int i = 0; i < zoneToDisplay.Length; i++)
        {
            if (zoneToDisplay[i].sprite == null) zoneToDisplay[i].sprite = upgrade.sprite;
            break;
        }
    }
}
