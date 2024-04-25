using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceScriptableObject _resourceScriptableObject;

    private protected string _resourceName;
    private ToolType _harvestingTool;
    private ResourceType _resourceType;
    private ProductType _extractionResult;
    private protected float _miningTime;
    private float _refreshResourceTime;
    private protected string _resourceDescription;

    [SerializeField] private CreateObject _factory;

    [SerializeField] private Transform _spawnResource;

    [SerializeField] private GameObject _resourceModel;

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

    public ProductType ExtractionResult
    {
        get { return _extractionResult; }
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

    public CreateObject Factory
    {
        get { return _factory; }
    }

    public Transform SpawnResource
    { 
        get { return _spawnResource; }
    }

    public GameObject ResourceModel
    { 
        get { return _resourceModel; }
    }

    private void Start()
    {
        _resourceName = _resourceScriptableObject.ResourceName;
        _harvestingTool = _resourceScriptableObject.HarvestingTool;
        _resourceType = _resourceScriptableObject.ResourceType;
        _extractionResult = _resourceScriptableObject.HarvestingResult;
        _miningTime = _resourceScriptableObject.MiningTime;
        _refreshResourceTime = _resourceScriptableObject.RefreshResourceTime;
        _resourceDescription = _resourceScriptableObject.ResourceDescription;
    }
}