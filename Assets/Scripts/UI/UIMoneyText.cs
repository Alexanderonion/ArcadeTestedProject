using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    private TextMeshProUGUI _moneyAmount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        Player.ChangeOfTheMoneyAmount += ChangeOfTheMoneyAmount;
    }

    private void OnDisable()
    {
        Player.ChangeOfTheMoneyAmount -= ChangeOfTheMoneyAmount;
    }

    private void Start()
    {
        _moneyAmount = GetComponent<TextMeshProUGUI>();
    }

    private void ChangeOfTheMoneyAmount()
    {
        _moneyAmount.text = _player.AmountOfMoney.ToString();
    }
}