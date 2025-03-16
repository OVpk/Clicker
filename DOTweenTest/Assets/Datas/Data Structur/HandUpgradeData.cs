using UnityEngine;

[CreateAssetMenu(menuName = "Data/Upgrade/HandUpgrade")]
public class HandUpgradeData : UpgradeData
{
    [field: Header("Delay Between hand auto-click"),SerializeField]
    public float newDelay { get; private set; }

    public HandDataInstance Instance()
    {
        return new HandDataInstance(this);
    }
}

public class HandDataInstance
{
    public float delay;

    public HandDataInstance(HandUpgradeData data)
    {
        delay = data.newDelay;
    }
}