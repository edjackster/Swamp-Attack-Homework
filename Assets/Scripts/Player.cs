using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private int _money;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private int _currentWeaponIndex = 0;
    private Animator _animator;
    
    public int Money => _money;
    public List<Weapon> Weapons => _weapons;
    public Weapon CurrentWeapon => _currentWeapon;

    public event Action<int> MoneyChanged;
    public event Action<Weapon> CurrentWeaponChanged;
    public event Action<Weapon> WeaponsAdded;
    public event Action<int,int> HealthChanged;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _currentWeapon.Shoot(_shootingPoint);
        
        if(Input.GetKeyDown(KeyCode.W))
            NextWeapon();
        
        if(Input.GetKeyDown(KeyCode.S))
            PreviousWeapon();
    }

    public void NextWeapon()
    {
        if (++_currentWeaponIndex >= _weapons.Count)
            _currentWeaponIndex = 0;
        
        SetCurrentWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (--_currentWeaponIndex < 0)
            _currentWeaponIndex = _weapons.Count - 1;
        
        SetCurrentWeapon(_weapons[_currentWeaponIndex]);
    }

    public void AddMoney(int amount)
    {
        _money += amount;
        MoneyChanged?.Invoke(_money);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        
        HealthChanged?.Invoke(_currentHealth, _health);
        
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(_money);
        WeaponsAdded?.Invoke(weapon);
    }

    private void SetCurrentWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        CurrentWeaponChanged?.Invoke(weapon);
    }
}
