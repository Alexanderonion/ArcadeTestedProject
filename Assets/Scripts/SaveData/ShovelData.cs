using System;

[Serializable]
public class ShovelData : HarvestingToolData
{
    public ShovelData()
    {
        _level = 0;
        _isAvailable = false;
    }
}