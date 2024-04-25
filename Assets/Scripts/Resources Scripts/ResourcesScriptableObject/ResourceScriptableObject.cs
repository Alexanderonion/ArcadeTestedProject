using UnityEngine;

[CreateAssetMenu(fileName = "Create object", menuName = "Arcade Idle/Resource/New Resource")]
public class ResourceScriptableObject : ScriptableObject
{
    [SerializeField] private protected string _resourceName;
    [SerializeField] private ToolType _harvestingTool;
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private ProductType _harvestingResult;
    [SerializeField] private protected float _miningTime;
    [SerializeField] private float _refreshResourceTime;

    [TextArea]
    [SerializeField] private string _resourceDescription;

    public string ResourceName
    {
        get { return _resourceName; }
    }
    public ToolType HarvestingTool
    {
        get { return _harvestingTool; }
    }

    public ResourceType ResourceType
    {
        get { return _resourceType; }
    }

    public ProductType HarvestingResult
    {
        get { return _harvestingResult; }
    }

    public float MiningTime
    {
        get { return _miningTime; }
    }

    public float RefreshResourceTime
    {
        get { return _refreshResourceTime; }
    }

    public string ResourceDescription
    {
        get { return _resourceDescription; }
    }
}
