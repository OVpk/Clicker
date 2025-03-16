using UnityEngine;

[CreateAssetMenu(menuName = "Data/ColorZoneData")]
public class ColorZoneData : ScriptableObject
{
    public enum Colors
    {
        Yellow,
        Red,
        Green,
        Blue
    }
    
    [field: Header("Color"),SerializeField]
    public Colors color { get; private set; }
    
    [field: Header("Points per Click"),SerializeField]
    public int points { get; private set; }

    public ColorZoneDataInstance Instance()
    {
        return new ColorZoneDataInstance(this);
    }
}

public class ColorZoneDataInstance
{
    public ColorZoneData.Colors color;
    public int points;
    public HandDataInstance handInstance;

    public ColorZoneDataInstance(ColorZoneData data)
    {
        color = data.color;
        points = data.points;
    }
}