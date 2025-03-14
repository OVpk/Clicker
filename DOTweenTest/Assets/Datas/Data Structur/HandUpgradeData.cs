using UnityEngine;

[CreateAssetMenu(menuName = "Data/Upgrade/HandUpgrade")]
public class HandUpgradeData : UpgradeData
{
    [field: Header("Hand to upgrade"),SerializeField]
    public HandData hand { get; private set; }
    
    [field: Header("Upgrade Delay Between hand auto-click"),SerializeField]
    public float newDelay { get; private set; }
}