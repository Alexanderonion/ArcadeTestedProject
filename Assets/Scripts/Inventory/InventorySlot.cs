using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ProductType _productType;
    private int _amountItem;
    private bool _isEmpty = true;
    private string _discriptionProduct;

    [SerializeField] private TMP_Text _amountOfItemInInventorySlotText;
    [SerializeField] private Image _itemInventoryIcon;
    [SerializeField] private Image _defaultInventoryIcon;
    [SerializeField] private ProductScriptableObject[] _availableProductsPerSlot;

    public ProductType ProductType
    {
        get { return _productType; }
    }

    public int AmountItem
    {
        get { return _amountItem; }
    }
    
    public bool IsEmpty
    {
        get { return _isEmpty; }
    }

    public string DiscriptionProduct
    {
        get { return _discriptionProduct; }
    }

    public TMP_Text AmountOfItemInInventorySlotText
    {
        get { return _amountOfItemInInventorySlotText; }
    }

    public void AddItemInSlot(ProductItem item)
    {
        if (_isEmpty)
        {
            _isEmpty = false;
            _productType = item.ProductType;
            _amountItem += item.Amount;
            _amountOfItemInInventorySlotText.text = _amountItem.ToString();
            _itemInventoryIcon.color = new Color(1, 1, 1, 1);
            _itemInventoryIcon.sprite = item.IconInInventorySlot;
            _amountOfItemInInventorySlotText.gameObject.SetActive(true);
            _itemInventoryIcon.gameObject.SetActive(true);
            _discriptionProduct = item.Description;
            Destroy(item.gameObject);
        }
        else if (!_isEmpty && _productType == item.ProductType && _amountItem + item.Amount <= item.MaximumAmountInInventorySlot)
        {
            _amountItem += item.Amount;
            _amountOfItemInInventorySlotText.text = _amountItem.ToString();
            Destroy(item.gameObject);
        }
    }
    
    public bool SubtractItemInSlot(ProductType productType, int subtrahend)
    {
        if (_productType == productType && _amountItem > 0)
        {
            _amountItem -= subtrahend;
            _amountOfItemInInventorySlotText.text = _amountItem.ToString();

            if (_amountItem == 0)
            {
                EmptySlot();
            }

            return true;
        }

        return false;
    }

    public void EmptySlot()
    {
        _isEmpty = true;
        _amountItem = 0;
        _amountOfItemInInventorySlotText.gameObject.SetActive(false);
        _itemInventoryIcon.gameObject.SetActive(false);
    }

    public void SetSlotValue(int amountItem, bool isEmpty, ProductType productType)
    {
        _isEmpty = isEmpty;

        if (_isEmpty)
        {
            return;
        }

        _amountItem = amountItem;
        _productType = productType;
        _amountOfItemInInventorySlotText.text = _amountItem.ToString();

        foreach (var item in _availableProductsPerSlot)
        {
            if (item.ProductType == productType)
            {
                _itemInventoryIcon.color = new Color(1, 1, 1, 1);
                _itemInventoryIcon.sprite = item.IconInInventorySlot;
                _discriptionProduct = item.Description;
            }
        }

        _amountOfItemInInventorySlotText.gameObject.SetActive(true);
        _itemInventoryIcon.gameObject.SetActive(true);
    }
}