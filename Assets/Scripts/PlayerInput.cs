using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveValue;

    [SerializeField] private float _rotateValue;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private UIInventory _inventory;

    private float _currentRotation;

    private Vector3 _moveAmount;

    private void Update()
    {
        Move(_moveValue);
        Rotate(_rotateValue);
    }

    private void Move(float directionMove)
    {
        _moveAmount = transform.forward * directionMove * _moveSpeed * Time.deltaTime;
        transform.position += _moveAmount;
    }

    private void Rotate(float rotateDirection)
    {
        _currentRotation += rotateDirection * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<float>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        _rotateValue = context.ReadValue<float>();
    }
    
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (_inventory.transform.GetChild(0).gameObject.activeSelf)
        {
            _inventory.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            _inventory.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}