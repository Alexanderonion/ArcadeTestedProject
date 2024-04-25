using UnityEngine;

public class ProductItem : MonoBehaviour
{
    [SerializeField] private ProductScriptableObject _productScriptableObject;

    private string _name;
    private ProductType _productType;
    private int _amount;
    private int _maximumAmountInInventorySlot;
    private Sprite _iconInInventorySlot;
    private string _description;

    public string Name
    {
        get { return _name; }
    }

    public ProductType ProductType
    {
        get { return _productType; }
    }

    public int Amount
    {
        get { return _amount; }
    }

    public int MaximumAmountInInventorySlot
    {
        get { return _maximumAmountInInventorySlot; }
    }

    public Sprite IconInInventorySlot
    {
        get { return _iconInInventorySlot; }
    }

    public string Description
    {
        get { return _description; }
    }

    private void Start()
    {
        _name = _productScriptableObject.Name;
        _productType = _productScriptableObject.ProductType;
        _amount = _productScriptableObject.Amount;
        _maximumAmountInInventorySlot = _productScriptableObject.MaximumAmountInInventorySlot;
        _iconInInventorySlot = _productScriptableObject.IconInInventorySlot;
        _description = _productScriptableObject.Description;
    }
}