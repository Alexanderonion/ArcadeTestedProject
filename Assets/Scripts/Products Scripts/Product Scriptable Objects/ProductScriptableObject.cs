using UnityEngine;

[CreateAssetMenu(fileName = "Create object", menuName = "Arcade Idle/Items/New Product Item")]
public class ProductScriptableObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private ProductType _productType;
    [SerializeField] private int _amount;
    [SerializeField] private int _maximumAmountInInventorySlot;
    [SerializeField] private Sprite _iconInInventorySlot;

    [TextArea]
    [SerializeField] private string _description;

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
}