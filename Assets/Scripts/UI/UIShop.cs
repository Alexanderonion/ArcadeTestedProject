using System;
using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _shovelCostText;
    [SerializeField] private TextMeshProUGUI _pickCostText;
    [SerializeField] private TextMeshProUGUI _productionBuidingsUpgradeCostText;
    
    [SerializeField] private ShopBuilding _shopBuilding;

    [SerializeField] private Player _player;

    private HarvestingTool _shovel;
    private HarvestingTool _pick;

    public static Action<ToolType, int> UpgradeTool;
    public static Action UpgradeBuildings;

    private void OnEnable()
    {
        Player.SetPriceTag += SetPriceTag;
    }

    private void OnDisable()
    {
        Player.SetPriceTag -= SetPriceTag;
    }

    void Start()
    {
        _shovel = _player.ToolSet[1];
        _pick = _player.ToolSet[2];

        SetPriceTag(_shovel);
        SetPriceTag(_pick);
    }

    public void OnUpgradeShovel()
    {
        UpgradeTool?.Invoke(ToolType.shovel, _shopBuilding.PriceCoefficient);
        SetPriceTag(_shovel);
    }

    public void OnUpgradePick()
    {
        UpgradeTool?.Invoke(ToolType.pick, _shopBuilding.PriceCoefficient);
        SetPriceTag(_pick);
    }

    public void OnProductionBuildingsUpgrade()
    {
        UpgradeBuildings?.Invoke();
    }

    private void SetPriceTag(HarvestingTool tool)
    {
        switch (tool.ToolType)
        {
            case ToolType.pick:
                _pickCostText.text = InstallButtonText(tool);
                break;
            case ToolType.shovel:
                _shovelCostText.text = InstallButtonText(tool);
                break;
            default:
                break;
        }
    }

    private string InstallButtonText(HarvestingTool tool)
    {
        if (tool.Level == 0 && tool.Level <= tool.ToolUpgradeCost.Count - 1)
        {
            return $"Buy {tool.Name} {tool.ToolUpgradeCost[tool.Level]}";
        }
        else if (tool.Level > 0 && tool.Level <= tool.ToolUpgradeCost.Count - 1)
        {
            return $"Upgrade {tool.Name} {tool.ToolUpgradeCost[tool.Level]}";
        }

        return $"the {tool.Name} has been improved";
    }
}