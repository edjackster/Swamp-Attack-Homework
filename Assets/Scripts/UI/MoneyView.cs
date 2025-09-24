using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        UpdateMoney(_player.Money);
        _player.MoneyChanged += UpdateMoney;
    }

    private void OnDisable()
    {
        _player.MoneyChanged += UpdateMoney;
    }

    private void UpdateMoney(int money)
    {
        _money.text = money.ToString();
    }
}
