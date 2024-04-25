using UnityEngine;

public class CreateObject : MonoBehaviour, IFactory
{
    [SerializeField] private Resource _pearTreePrefab;
    [SerializeField] private Resource _appleTreePrefab;
    [SerializeField] private Resource _goldMinePrefab;
    [SerializeField] private Resource _earthPilePrefab;

    [SerializeField] private ProductItem _pearPrefab;
    [SerializeField] private ProductItem _applePrefab;
    [SerializeField] private ProductItem _goldPrefab;
    [SerializeField] private ProductItem _clayPrefab;
    [SerializeField] private ProductItem _pearJuicePrefab;
    [SerializeField] private ProductItem _appleJuicePrefab;
    [SerializeField] private ProductItem _goldBarPrefab;
    [SerializeField] private ProductItem _brickPrefab;

    [SerializeField] private ProductionBuilding _productionAppleJuiceBuildingPrefab;
    [SerializeField] private ProductionBuilding _productionPearJuiceBuildingPrefab;
    [SerializeField] private ProductionBuilding _productionGoldBarBuildingPrefab;
    [SerializeField] private ProductionBuilding _productionBrickBuildingPrefab;
    [SerializeField] private ShopBuilding _shopBuildingPrefab;
    
    public Building CreateBuild(BuildingType type, Transform transform)
    {
        switch (type)
        {
            case BuildingType.productionPairJuiceBuilding:
                return Instantiate(_productionPearJuiceBuildingPrefab, transform);
            case BuildingType.productionAppleJuiceBuilding:
                return Instantiate(_productionAppleJuiceBuildingPrefab, transform);
            case BuildingType.productionGoldBarBuilding:
                return Instantiate(_productionGoldBarBuildingPrefab, transform);
            case BuildingType.productionBrickBuilding:
                return Instantiate(_productionBrickBuildingPrefab, transform);
            case BuildingType.shopBuilding:
                return Instantiate(_shopBuildingPrefab, transform);

            default:
                Debug.LogError("there is no such building");
                return null;
        }
    }

    public ProductItem CreateProduct(ProductType type, Transform transform)
    {
        switch (type)
        {
            case ProductType.pear:
                return Instantiate(_pearPrefab, transform);
            case ProductType.apple:
                return Instantiate(_applePrefab, transform);
            case ProductType.gold:
                return Instantiate(_goldPrefab, transform);
            case ProductType.clay:
                return Instantiate(_clayPrefab, transform);
            case ProductType.brick:
                return Instantiate(_brickPrefab, transform);
            case ProductType.goldBar:
                return Instantiate(_goldBarPrefab, transform);
            case ProductType.appleJuice:
                return Instantiate(_appleJuicePrefab, transform);
            case ProductType.pearJuce:
                return Instantiate(_pearJuicePrefab, transform);

            default:
                Debug.LogError("there is no such product");
                return null;
        }
    }

    public Resource CreateResource(ResourceType type, Transform transform)
    {
        switch (type)
        {
            case ResourceType.pearTree:
                return Instantiate(_pearTreePrefab, transform);

            case ResourceType.appleTree:
                return Instantiate(_appleTreePrefab, transform);

            case ResourceType.goldMine:
                return Instantiate(_goldMinePrefab, transform);

            case ResourceType.earthPile:
                return Instantiate(_earthPilePrefab, transform);

            default:
                Debug.LogError("there is no such resource");
                return null;
        }
    }
}