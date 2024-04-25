using System;
using UnityEngine;

public class StorageInTriggerZone : MonoBehaviour
{
    private ProductionBuilding _productionBuilding;
    private float _timer;
    private float _unloadConfirmationTime;
    private bool _unloading;
    private int _takeAnAmountOfProduct;

    void Start()
    {
        _productionBuilding = transform.parent.parent.GetComponent<ProductionBuilding>();
        _timer = 0;
        _unloading = false;
        _unloadConfirmationTime = 1f;
        _takeAnAmountOfProduct = 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Player>())
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _unloadConfirmationTime && _productionBuilding.ProductInAmount < _productionBuilding.MaximumAmountProductInStorage)
        {
            _unloading = true;
        }

        if (_timer >= _productionBuilding.TimeOfTakingProductIn && _unloading)
        {
            if (other.GetComponent<Player>().Inventory.GetComponent<UIInventory>().SubtractItem(_productionBuilding.ProductIn, _takeAnAmountOfProduct))
            {
                _productionBuilding.GiveProduct(_takeAnAmountOfProduct);
            }

            _timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Player>())
        {
            return;
        }

        _timer = 0;
        _unloading = false;
    }
}