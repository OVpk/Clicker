using UnityEngine;

[CreateAssetMenu(menuName = "Data/Upgrade/ColorUpgrade")]
public class ColorUpgradeData : UpgradeData
{
    [field: Header("Upgrade Points per Click"),SerializeField]
    public int pointsToAdd { get; private set; }
}