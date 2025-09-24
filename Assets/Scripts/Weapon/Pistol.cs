using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootingPoint)
    {
        Instantiate(Bullet, shootingPoint.position, shootingPoint.rotation);
    }
}
