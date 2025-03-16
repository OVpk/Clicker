using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.currentState == GameManager.GameState.Game)
        {
            DetectZone();
        }
    }

    void DetectZone()
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

    public void ItemButtonClick(int index)
    {
        if (GameManager.Instance.upgrades[index] != null)
        {
            GameManager.Instance.BuyUpgrade(GameManager.Instance.upgrades[index]);
        }
    }
}
