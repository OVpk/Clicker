using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopDoTweenController : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 closedPosition;

    [SerializeField] private Image shopButton;
    [SerializeField] private Sprite openArrow;
    [SerializeField] private Sprite closedArrow;

    private void Start()
    {
        transform.localPosition = closedPosition;
        shopButton.sprite = closedArrow;
    }

    public void OpenCloseShop(bool state)
    {
        Vector3 newPosition = state ? openPosition : closedPosition;
        Sprite newButtonSprite = state ? openArrow : closedArrow;
        transform.DOLocalMove(newPosition, 1f).SetEase(Ease.OutBack).OnComplete(
            () =>
            {
                shopButton.sprite = newButtonSprite;
            });
    }
}
