using UnityEngine;

[CreateAssetMenu(fileName = "Create object", menuName = "Arcade Idle/Buildings/New Production Building")]
public class ProductionBuildingScriptableObject : BuildingScriptableObject
{
    [SerializeField] private int _productionTime;
    [SerializeField] private ProductType _productIn;
    [SerializeField] private ProductType _productOut;

    [SerializeField] private int _maximumAmountProductInStorage;
    [SerializeField] private int _maximumAmountProductOutStorage;

    [SerializeField] private int _level;
    [SerializeField] private int _levelUpKoefficient;

    [SerializeField] private float _timeOfTakingProductIn;
    [SerializeField] private float _timeOfGiveAwayProductOut;

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
}