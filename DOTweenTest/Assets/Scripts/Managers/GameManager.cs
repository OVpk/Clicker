using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HandData[] hands;
    private HandDataInstance yellowHand;
    private HandDataInstance redHand;
    private HandDataInstance blueHand;
    private HandDataInstance greenHand;
    
    public enum GameState
    {
        Game,
        Shop,
        Menu
    }
    public GameState currentState { get; private set; }
    
    public enum Colors
    {
        Yellow,
        Red,
        Green,
        Blue
    }
    
    public int score { get; private set; }
    
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

        foreach (var hand in hands)
        {
            switch (hand.color)
            {
                case Colors.Red : redHand = hand.Instance();break;
                case Colors.Green : greenHand = hand.Instance();break;
                case Colors.Blue : blueHand = hand.Instance();break;
                case Colors.Yellow : yellowHand = hand.Instance();break;
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

    public void ColorClick(Colors clickedColor)
    {
        DisplayManager.Instance.DisplayClickedColor(clickedColor);
        AddScore(1);
        DisplayManager.Instance.DisplayScore();
    }

    private IEnumerator HandAutoClicker(HandDataInstance hand)
    {
        while (currentState == GameState.Game)
        {
            DisplayManager.Instance.DisplayHandAt(hand.color);
            yield return new WaitForSeconds(0.25f);
            ColorClick(hand.color);

            yield return new WaitForSeconds(hand.delay);
        }
    }

    private void ApplyHandUpgrade(HandUpgradeData handUpgrade)
    {
        HandDataInstance handToUpgrade = handUpgrade.hand.color switch
        {
            Colors.Yellow => yellowHand,
            Colors.Red => redHand,
            Colors.Blue => blueHand,
            Colors.Green => greenHand,
            _ => throw new ArgumentOutOfRangeException()
        };
        handToUpgrade.delay = handUpgrade.newDelay;
    }

    private void StartNewHand(HandDataInstance hand)
    {
        StartCoroutine(HandAutoClicker(hand));
    }

}
