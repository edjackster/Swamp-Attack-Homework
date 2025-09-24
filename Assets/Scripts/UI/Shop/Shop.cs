using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _prefab;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _container;

    private void Start()
    {
        foreach (Weapon weapon in _weapons)
        {
            AddWeapon(weapon);
        }
    }

    private void AddWeapon(Weapon weapon)
    {
        var view = Instantiate(_prefab, _container);
        
        view.Render(weapon);
        view.Sell += OnSell;
    }

    private void OnSell(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            view.Sell -= OnSell;
        }
    }
}
