using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _price;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    
    private Weapon _weapon;
    public bool _isBuyed;

    public event Action<Weapon, WeaponView> Sell;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        _button.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _button.onClick.RemoveListener(TryLockItem);
    }
    
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _name.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _image.sprite = weapon.Icon;
        _isBuyed = weapon.IsBuyed;
        TryLockItem();
    }

    private void TryLockItem()
    {
        if(_isBuyed)
            _button.interactable = false;
    }

    private void OnButtonClick()
    {
        _isBuyed = true;
        Sell?.Invoke(_weapon, this);
    }
}
