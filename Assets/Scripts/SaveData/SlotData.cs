using System;

[Serializable]
public class SlotData
{
    public ProductType _productType;
    public int _amountItem;
    public bool _isEmpty;
    public string _discriptionProduct;

    public SlotData()
    {
        _productType = ProductType.pear;
        _amountItem = 0;
        _isEmpty = true;
        _discriptionProduct = "";
    }
}