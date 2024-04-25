using System;
using UnityEngine;
using TMPro;

public class ShopBuilding : Building
{
    [SerializeField] private ShopBuildingScriptableObject _shopBuildingScriptableObject;

    private int _priceCoefficient;
    
    public int PriceCoefficient
    {
        get { return _priceCoefficient; }
    }

    void Start()
    {
        _priceCoefficient = _shopBuildingScriptableObject.PriceCoefficient;
        _buildingName = _shopBuildingScriptableObject.BuildingName;
        _buildingDescription = _shopBuildingScriptableObject.BuildingDescription;
    }
}