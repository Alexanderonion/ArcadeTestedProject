using UnityEngine;

public class BuildingScriptableObject : ScriptableObject
{
    [SerializeField] private string _buildingName;

    [TextArea]
    [SerializeField] private string _buildingDescription;

    public string BuildingName
    {
        get { return _buildingName; }
    }

    public string BuildingDescription
    {
        get { return _buildingDescription; }
    }
}