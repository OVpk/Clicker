using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.currentState == GameManager.GameState.Game)
        {
            DetectZone();
        }
    }

    private void DetectZone()
    {
        if (GameManager.Instance.currentState != GameManager.GameState.Game) return;
        
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x < screenWidth / 2 && mousePosition.y < screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Instance.redZone);
        }
        else if (mousePosition.x >= screenWidth / 2 && mousePosition.y < screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Instance.greenZone);
        }
        else if (mousePosition.x < screenWidth / 2 && mousePosition.y >= screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Instance.yellowZone);
        }
        else if (mousePosition.x >= screenWidth / 2 && mousePosition.y >= screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Instance.blueZone);
        }
    }

    public void ShopButtonClick()
    {
        GameManager.GameState newState = GameManager.Instance.currentState == GameManager.GameState.Shop
            ? GameManager.GameState.Game
            : GameManager.GameState.Shop;
        GameManager.Instance.ChangeState(newState);
        DisplayManager.Instance.DisplayShop(GameManager.Instance.currentState == GameManager.GameState.Shop);
    }

    public void ItemButtonClick(int index)
    {
        if (GameManager.Instance.upgrades[index] != null)
        {
            GameManager.Instance.BuyUpgrade(GameManager.Instance.upgrades[index]);
        }
    }
}
