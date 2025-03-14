using UnityEngine;

[CreateAssetMenu(menuName = "Data/HandData")]
public class HandData : ScriptableObject
{
    [field: Header("Color to click"),SerializeField]
    public GameManager.Colors color { get; private set; }
    
    [field: Header("Delay Between auto-click at start"),SerializeField]
    public float delay { get; private set; }
    
    [field: Header("DoTween Controller"),SerializeField]
    public HandController controller { get; private set; }

    public HandDataInstance Instance()
    {
        return new HandDataInstance(this);
    }
}

public class HandDataInstance
{
    public GameManager.Colors color;
    public float delay;
    public HandController controller;

    public HandDataInstance(HandData data)
    {
        color = data.color;
        delay = data.delay;
        controller = data.controller;
    }
}