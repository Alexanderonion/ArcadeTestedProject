using UnityEngine;
using System.Collections;

public class ProductionBuilding : Building
{
    #region variables
    [SerializeField] private ProductionBuildingScriptableObject _productionBuildingScriptableObject;
    [SerializeField] private CreateObject _factory;
    [SerializeField] private Transform _storageOut;

    private int _productionTime;

    private ProductType _productIn;
    private ProductType _productOut;

    private int _productInAmount;
    private int _productOutAmount;

    private int _maximumAmountProductInStorage;
    private int _maximumAmountProductOutStorage;

    private float _timeOfTakingProductIn;
    private float _timeOfGiveAwayProductOut;

    private int _level;

    private int _levelUpKoefficient;

    private bool _isProduction;

    public int ProductionTime
    {
        get { return _productionTime; }
    }

    public ProductType ProductIn
    {
        get { return _productIn; }
    }

    public ProductType ProductOut
    {
        get { return _productOut; }
    }

    public string BuildingName
    {
        get { return _buildingName; }
    }
    
    public string BuildingDescription
    {
        get { return _buildingDescription; }
    }

    public int ProductInAmount
    {
        get { return _productInAmount; }
    }

    public int ProductoutAmount
    {
        get { return _productOutAmount; }
    }

    public int MaximumAmountProductInStorage
    {
        get { return _maximumAmountProductInStorage; }
    }
    
    public int MaximumAmountProductOutStorage
    {
        get { return _maximumAmountProductOutStorage; }
    }

    public int Level
    {
        get { return _level; }
    }

    public int LevelUpKoefficient
    {
        get { return _levelUpKoefficient; }
    }

    public float TimeOfTakingProductIn
    {
        get { return _timeOfTakingProductIn; }
    }

    public float TimeOfGiveAwayProductOut
    {
        get { return _timeOfGiveAwayProductOut; }
    }
    #endregion

    private void OnEnable()
    {
        UIShop.UpgradeBuildings += BuildLevelUp;
    }

    private void OnDisable()
    {
        UIShop.UpgradeBuildings -= BuildLevelUp;
    }

    void Start()
    {
        _buildingName = _productionBuildingScriptableObject.BuildingName;
        _buildingDescription = _productionBuildingScriptableObject.BuildingDescription;
        _productionTime = _productionBuildingScriptableObject.ProductionTime;
        _productIn = _productionBuildingScriptableObject.ProductIn;
        _productOut = _productionBuildingScriptableObject.ProductOut;
        _maximumAmountProductInStorage = _productionBuildingScriptableObject.MaximumAmountProductInStorage;
        _maximumAmountProductOutStorage = _productionBuildingScriptableObject.MaximumAmountProductOutStorage;
        _timeOfTakingProductIn = _productionBuildingScriptableObject.TimeOfTakingProductIn;
        _timeOfGiveAwayProductOut = _productionBuildingScriptableObject.TimeOfGiveAwayProductOut;
        _level = _productionBuildingScriptableObject.Level;
        _levelUpKoefficient = _productionBuildingScriptableObject.LevelUpKoefficient;
        _isProduction = false;
    }

    private IEnumerator Production()
    {
        while (_productInAmount > 0 && _productOutAmount < _maximumAmountProductOutStorage)
        {
            _isProduction = true;
            yield return new WaitForSeconds(_productionTime);
            _productInAmount--;
            _factory.CreateProduct(_productOut, _storageOut);
        }

        _isProduction = false;
    }

    private void BuildLevelUp()
    {
        _level++;
        _maximumAmountProductInStorage *= _levelUpKoefficient;
        _maximumAmountProductOutStorage *= _levelUpKoefficient;
        _productionTime /= _levelUpKoefficient;
    }

    public void GiveProduct(int productAmount)
    {
        _productInAmount += productAmount;

        if (!_isProduction)
        {
            StartCoroutine(Production());
        }
    }
}