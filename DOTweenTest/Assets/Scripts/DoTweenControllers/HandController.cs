using DG.Tweening;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private Vector3 retractedScale;
    [SerializeField] private Vector3 retractedPosition;

    [SerializeField] private Vector3 normalScale;
    [SerializeField] private Vector3 normalPosition;

    private void Start()
    {
        transform.localPosition = retractedPosition;
        transform.localScale = retractedScale;
    }

    public void HandClick()
    {
        transform.DOLocalMove(normalPosition, 0.25f).SetEase(Ease.OutBounce);
        transform.DOScale(normalScale, 0.25f).SetEase(Ease.OutBounce).OnComplete(
            () =>
            {
                transform.DOLocalMove(retractedPosition, 0.25f).SetEase(Ease.OutBounce);
                transform.DOScale(retractedScale, 0.25f).SetEase(Ease.OutBounce);
            });
    }
}
