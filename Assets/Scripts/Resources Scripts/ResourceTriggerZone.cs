using System.Collections;
using UnityEngine;

public class ResourceTriggerZone : MonoBehaviour
{
    private Resource _resource;

    private bool _isHarvested;

    private bool _refreshing;

    private float _timer;

    public bool IsHarvested
    {
        get { return _isHarvested; }
    }

    private void Start()
    {
        _resource = transform.parent?.GetComponent<Resource>();
        _isHarvested = true;
        _refreshing = true;
        _timer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        _timer += Time.deltaTime;

        if (!other.GetComponent<Player>() || !ToolIsAvailable(other.GetComponent<Player>()))
        {
            return;
        }

        if (_timer >= _resource.MiningTime / other.GetComponent<Player>().SpeedHarvesting(_resource.HarvestingTool) && _isHarvested)
        {
            HarvestingResource();
        }
    }

    private void OnTriggerExit()
    {
        if (!_refreshing)
        {
            StartCoroutine(RefreshResource());
        }
    }

    private IEnumerator RefreshResource()
    {
        _refreshing = true;
        yield return new WaitForSeconds(_resource.RefreshResourceTime);
        _timer = 0;
        _resource.ResourceModel.SetActive(true);
        _isHarvested = true;
    }

    private void HarvestingResource()
    {
        _resource.Factory.CreateProduct(_resource.ExtractionResult, _resource.SpawnResource);
        _resource.ResourceModel.SetActive(false);
        _refreshing = false;
        _isHarvested = false;
    }

    private bool ToolIsAvailable(Player player)
    {
        foreach (HarvestingTool item in player.ToolSet)
        {
            if (item.ToolType == _resource.HarvestingTool && item.IsAvailable)
            {
                return true;
            }
        }
        
        return false;
    }
}