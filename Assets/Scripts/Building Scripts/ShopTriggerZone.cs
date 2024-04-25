using UnityEngine;

public class ShopTriggerZone : MonoBehaviour
{
    [SerializeField] private GameObject _shopMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _shopMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _shopMenu.SetActive(false);
    }
}