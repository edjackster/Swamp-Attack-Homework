using System.Collections.Generic;
using UnityEngine;

public class ArsenalView : MonoBehaviour
{
    [SerializeField] private PlayerWeaponView _prefab;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _container;

    private List<PlayerWeaponView> _views = new List<PlayerWeaponView>();
    
    private void Start()
    {
        foreach (Weapon weapon in _player.Weapons)
        {
            AddWeapon(weapon);
        }

        OnCurrentWeaponChanged(_player.CurrentWeapon);
    }

    private void OnEnable()
    {
        _player.WeaponsAdded += AddWeapon;
        _player.CurrentWeaponChanged += OnCurrentWeaponChanged;
    }

    private void OnDisable()
    {
        _player.WeaponsAdded -= AddWeapon;
        _player.CurrentWeaponChanged -= OnCurrentWeaponChanged;
    }

    private void AddWeapon(Weapon weapon)
    {
        var view = Instantiate(_prefab, _container);
        
        view.Render(weapon);
        _views.Add(view);
    }

    private void OnCurrentWeaponChanged(Weapon weapon)
    {
        foreach (var view in _views)
        {
            if (weapon != view.Weapon)
                view.Unselect();
            else
                view.Select();
        }
    }
}
