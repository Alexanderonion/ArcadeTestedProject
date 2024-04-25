using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateObject", menuName = "Arcade Idle/HarvestingTool/New Harvesting tool") ]
public class HarvestingToolScriptableObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private ToolType _toolType;
    [SerializeField] private int _level;
    [SerializeField] private List<int> _toolUpgradeCost;
    [SerializeField] private bool _isAvailable;
    [TextArea] [SerializeField] private string _description;

    public string Name
    {
        get { return _name; }
    }

    public ToolType ToolType
    {
        get { return _toolType; }
    }

    public int Level
    {
        get { return _level; }
    }

    public List<int> ToolUpgradeCost
    {
        get { return _toolUpgradeCost; }
    }

    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public string Description
    {
        get { return _description; }
    }
}