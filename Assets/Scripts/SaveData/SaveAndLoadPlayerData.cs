using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class SaveAndLoadPlayerData : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HarvestingTool _shovel;
    [SerializeField] private HarvestingTool _pick;
    private InventoryData _inventorySlots;
    PlayerData _playerData;
    ShovelData _shovelData;
    PickData _pickData;

    private void Start()
    {
        _inventorySlots = new InventoryData();
        _playerData = new PlayerData();
        _shovelData = new ShovelData();
        _pickData = new PickData();
    }

    public void OnSave()
    {
        _playerData._amountOfMoney = _player.AmountOfMoney;
        _shovelData._level = _player.Shovel.Level;
        _shovelData._isAvailable = _player.Shovel.IsAvailable;
        _pickData._level = _player.Pick.Level;
        _pickData._isAvailable = _player.Pick.IsAvailable;

        for (int i = 0; i < _player.Inventory.Slots.Count; i++)
        {
            if (_inventorySlots.Slots.Count < _player.Inventory.Slots.Count)
            {
                _inventorySlots.Slots.Add(new SlotData());
            }

            _inventorySlots.Slots[i]._amountItem = _player.Inventory.Slots[i].AmountItem;
            _inventorySlots.Slots[i]._isEmpty = _player.Inventory.Slots[i].IsEmpty;
            _inventorySlots.Slots[i]._productType = _player.Inventory.Slots[i].ProductType;
            _inventorySlots.Slots[i]._discriptionProduct = _player.Inventory.Slots[i].DiscriptionProduct;

        }

        string jsonWritePlayer = JsonUtility.ToJson(_playerData);
        string jsonWriteShovel = JsonUtility.ToJson(_shovelData);
        string jsonWritePick = JsonUtility.ToJson(_pickData);
        string jsonWriteInventorySlots = JsonUtility.ToJson(_inventorySlots);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", jsonWritePlayer);
        File.WriteAllText(Application.persistentDataPath + "/ShovelData.json", jsonWriteShovel);
        File.WriteAllText(Application.persistentDataPath + "/PickData.json", jsonWritePick);
        File.WriteAllText(Application.persistentDataPath + "/InventorySlots.json", jsonWriteInventorySlots);
    }

    public void OnLoad()
    {
        string playerPath = Application.persistentDataPath + "/PlayerData.json";
        string shovelPath = Application.persistentDataPath + "/ShovelData.json";
        string pickPath = Application.persistentDataPath + "/PickData.json";
        string inventorySlotsPath = Application.persistentDataPath + "/InventorySlots.json";

        if (File.Exists(playerPath))
        {
            string json = File.ReadAllText(playerPath);
            _playerData = JsonUtility.FromJson<PlayerData>(json);
            _player.SetAmountOfMoney(_playerData._amountOfMoney);
        }
        
        if (File.Exists(shovelPath))
        {
            string json = File.ReadAllText(shovelPath);
            _shovelData = JsonUtility.FromJson<ShovelData>(json);
            _shovel.SetLevelOfTool(_shovelData._level);
            _shovel.SetToolAvailability(_shovelData._isAvailable);
        }

        if (File.Exists(pickPath))
        {
            string json = File.ReadAllText(pickPath);
            _pickData = JsonUtility.FromJson<PickData>(json);
            _pick.SetLevelOfTool(_pickData._level);
            _pick.SetToolAvailability(_pickData._isAvailable);
        }

        if (File.Exists(shovelPath) && File.Exists(pickPath))
        {
            _player.SetToolSet();
            Player.SetPriceTag?.Invoke(_shovel);
            Player.SetPriceTag?.Invoke(_pick);
        }

        if (File.Exists(inventorySlotsPath))
        {
            string json = File.ReadAllText(inventorySlotsPath);
            _inventorySlots = JsonUtility.FromJson<InventoryData>(json);
            _player.Inventory.SetInventorySlots(_inventorySlots.Slots);
        }
    }
}