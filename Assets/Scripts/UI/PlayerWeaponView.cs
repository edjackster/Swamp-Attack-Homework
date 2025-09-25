using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponView : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _image;
    [SerializeField] private Image _selectedIcon;
    
    private Weapon _weapon;

    public Weapon Weapon => _weapon;
    
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _name.text = weapon.Label;
        _image.sprite = weapon.Icon;
    }

    public void Select()
    {
        _selectedIcon.gameObject.SetActive(true);
    }

    public void Unselect()
    {
        _selectedIcon.gameObject.SetActive(false);
    }
}
