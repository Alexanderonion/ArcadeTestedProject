using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarvestingTool : MonoBehaviour
{
    [SerializeField] private HarvestingToolScriptableObject _harvestingToolScriptableObject;

    private string _name;
    private ToolType _toolType;
    private int _level;
    private List<int> _toolUpgradeCost;
    private bool _isAvailable;
    private string _description;


    public HarvestingToolScriptableObject HarvestingToolScriptableObject
    {
        get { return _harvestingToolScriptableObject; }
    }

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

    private void Start()
    {
        _name = _harvestingToolScriptableObject.Name;
        _toolType = _harvestingToolScriptableObject.ToolType;
        _level = _harvestingToolScriptableObject.Level;
        _toolUpgradeCost = _harvestingToolScriptableObject.ToolUpgradeCost;
        _isAvailable = _harvestingToolScriptableObject.IsAvailable;
        _description = _harvestingToolScriptableObject.Description;
    }

    public void UpgradeTool()
    {
        _isAvailable = true;
        _level += 1;
    }

    public void SetLevelOfTool(int value)
    {
        _level = value;
    }

    public void SetToolAvailability(bool value)
    {
        _isAvailable = value;
    }
}