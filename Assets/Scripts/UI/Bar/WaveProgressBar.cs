using UnityEngine;

public class WaveProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;
    
    private void OnEnable()
    {
        _slider.value = 1;
        _spawner.EnemyCountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
    }
}
