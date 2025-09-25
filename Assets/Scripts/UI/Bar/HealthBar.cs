using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _slider.value = 1;
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
