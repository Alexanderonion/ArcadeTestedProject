using UnityEngine;

[CreateAssetMenu(fileName = "Create object", menuName = "Arcade Idle/Buildings/New Shop Building")]
public class ShopBuildingScriptableObject : BuildingScriptableObject
{
    [SerializeField] private int _priceCoefficient;

    public int PriceCoefficient
    {
        get { return _priceCoefficient; }
    }
}