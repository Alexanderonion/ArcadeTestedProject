using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] private UIInventory _inventory;
    [SerializeField] private HarvestingTool _hands;
    [SerializeField] private HarvestingTool _shovel;
    [SerializeField] private HarvestingTool _pick;

    private int _amountOfMoney;

    private List<HarvestingTool> _toolSet;

    public Player()
    {
        _inventory = new UIInventory();
        _hands = new HarvestingTool();
        _shovel = new HarvestingTool();
        _pick = new HarvestingTool();
        _amountOfMoney = 0;
        _toolSet = new List<HarvestingTool>();
    }

    public HarvestingTool Hands
    {
        get { return _hands; }
    }
    
    public HarvestingTool Shovel
    {
        get { return _shovel; }
    }
    
    public HarvestingTool Pick
    {
        get { return _pick; }
    }

    public int AmountOfMoney
    {
        get { return _amountOfMoney; }    
    }

    public List<HarvestingTool> ToolSet
    {
        get { return _toolSet; }
    }
    public UIInventory Inventory
    {
        get { return _inventory; }
    }

    public static Action<ProductItem> IsHarvested;
    public static Action<ProductItem> IsGivenAway;
    public static Action ChangeOfTheMoneyAmount;
    public static Action<HarvestingTool> SetPriceTag;

    private void OnEnable()
    {
        UIShop.UpgradeTool += UpgradeToolAvailable;
    }

    private void OnDisable()
    {
        UIShop.UpgradeTool -= UpgradeToolAvailable;
    }

    private void Awake()
    {
        _toolSet = new List<HarvestingTool> { _hands, _shovel, _pick };
    }

    private void Start()
    {
        ChangeAmountOfMoney(500);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ProductItem>() != null)
        {
            IsHarvested?.Invoke(other.gameObject.GetComponent<ProductItem>());
        }

        if (other.gameObject.GetComponent<StorageInTriggerZone>() != null)
        {
            IsGivenAway?.Invoke(other.gameObject.GetComponent<ProductItem>());
        }
    }

    private void UpgradeToolAvailable(ToolType toolType, int buyKoefficient)
    {
        foreach (HarvestingTool item in ToolSet)
        {
            if (toolType == item.ToolType && item.Level < item.ToolUpgradeCost.Count && AmountOfMoney >= item.ToolUpgradeCost[item.Level] * buyKoefficient)
            {
                ChangeAmountOfMoney(-(item.ToolUpgradeCost[item.Level] * buyKoefficient));
                item.UpgradeTool();
            }
        }
    }

    public void ChangeAmountOfMoney(int value)
    {
        _amountOfMoney += value;
        ChangeOfTheMoneyAmount?.Invoke();
    }

    public int SpeedHarvesting(ToolType toolType)
    {
        switch (toolType)
        {
            case ToolType.hands:
                return 1;
                break;
            case ToolType.pick:
                return _pick.Level;
                break;
            case ToolType.shovel:
                return _shovel.Level;
                break;
            default:
                return 1;
                break;
        }
    }

    public void SetAmountOfMoney(int value)
    {
        _amountOfMoney = value;
        ChangeOfTheMoneyAmount?.Invoke();
    }

    public void SetToolSet()
    {
        _toolSet[1] = _shovel;
        _toolSet[2] = _pick;
    }
}