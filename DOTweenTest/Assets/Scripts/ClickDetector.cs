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
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x < screenWidth / 2 && mousePosition.y < screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Colors.Red);
        }
        else if (mousePosition.x >= screenWidth / 2 && mousePosition.y < screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Colors.Green);
        }
        else if (mousePosition.x < screenWidth / 2 && mousePosition.y >= screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Colors.Yellow);
        }
        else if (mousePosition.x >= screenWidth / 2 && mousePosition.y >= screenHeight / 2)
        {
            GameManager.Instance.ColorClick(GameManager.Colors.Blue);
        }
    }
}
