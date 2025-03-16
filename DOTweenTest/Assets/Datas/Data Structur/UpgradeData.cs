using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    [field: Header("Price"),SerializeField]
    public int price { get; private set; }
    
    [field: Header("Color that owns the hand to upgrade"),SerializeField]
    public ColorZoneData colorZone { get; private set; }

    [field: Header("Visual"), SerializeField]
    public Sprite sprite { get; private set; }
    
}