using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Transform _distanceForPlayer;

    private void Start()
    {
        _distanceForPlayer = transform;
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _distanceForPlayer.transform.position.y, _player.transform.position.z);
    }
}