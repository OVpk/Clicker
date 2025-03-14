using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    [field: Header("Price"),SerializeField]
    public int price { get; private set; }
}