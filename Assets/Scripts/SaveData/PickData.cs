using System;

[Serializable]
public class PickData : HarvestingToolData
{
    public PickData()
    {
        _level = 0;
        _isAvailable = false;
    }
}