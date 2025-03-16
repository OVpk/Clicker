using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ColorZoneData[] colors;
    public ColorZoneDataInstance yellowZone { get; private set; }
    public ColorZoneDataInstance redZone { get; private set; }
    public ColorZoneDataInstance blueZone { get; private set; }
    public ColorZoneDataInstance greenZone { get; private set; }
    
    public enum GameState
    {
        Game,
        Shop,
        Menu
    }
    public GameState currentState { get; private set; }
    
    public int score { get; private set; }

    [SerializeField] public List<UpgradeData> upgrades;
    
    public static GameManager Instance;
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
        
        InitGame();
    }

    private void InitGame()
    {
        foreach (var color in colors)
        {
            switch (color.color)
            {
                case ColorZoneData.Colors.Red : redZone = color.Instance(); break;
                case ColorZoneData.Colors.Green : greenZone = color.Instance(); break;
                case ColorZoneData.Colors.Blue : blueZone = color.Instance(); break;
                case ColorZoneData.Colors.Yellow : yellowZone = color.Instance(); break;
            }
        }
    }

    private void Start()
    {
    }
    

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void ColorClick(ColorZoneDataInstance clickedColor)
    {
        DisplayManager.Instance.DisplayClickedColor(clickedColor.color);
        AddScore(clickedColor.points);
        DisplayManager.Instance.DisplayScore();
    }

    private IEnumerator HandAutoClicker(ColorZoneDataInstance colorToClick)
    {
        while (currentState == GameState.Game)
        {
            DisplayManager.Instance.DisplayHandAt(colorToClick.color);
            yield return new WaitForSeconds(0.25f);
            ColorClick(colorToClick);

            yield return new WaitForSeconds(colorToClick.handInstance.delay);
        }
    }

    private void RemoveItemToShop(UpgradeData upgrade)
    {
        upgrades.Remove(upgrade);
        DisplayManager.Instance.UpdateDisplayedShopItems();
    }

    public void BuyUpgrade(UpgradeData upgrade)
    {
        AddScore(- upgrade.price);
        RemoveItemToShop(upgrade);
        ApplyUpgrade(upgrade);
    }

    private void ApplyUpgrade(UpgradeData upgrade)
    {
        ColorZoneDataInstance zoneToUpgrade = upgrade.colorZone.color switch
        {
            ColorZoneData.Colors.Yellow => yellowZone,
            ColorZoneData.Colors.Red => redZone,
            ColorZoneData.Colors.Blue => blueZone,
            ColorZoneData.Colors.Green => greenZone,
            _ => throw new ArgumentOutOfRangeException(nameof(upgrade.colorZone), "ColorZoneData does not match any known zone.")
        };

        switch (upgrade)
        {
            case HandUpgradeData handUpgrade:
                if (zoneToUpgrade.handInstance == null)
                {
                    zoneToUpgrade.handInstance = handUpgrade.Instance();
                    StartNewHandAt(zoneToUpgrade);
                }
                zoneToUpgrade.handInstance.delay = handUpgrade.newDelay;
                break;

            case ColorUpgradeData colorUpgrade:
                zoneToUpgrade.points += colorUpgrade.pointsToAdd;
                break;

            default:
                throw new ArgumentException("Unsupported upgrade type", nameof(upgrade));
        }
    }
    
    private void StartNewHandAt(ColorZoneDataInstance colorZone)
    {
        StartCoroutine(HandAutoClicker(colorZone));
    }

}
