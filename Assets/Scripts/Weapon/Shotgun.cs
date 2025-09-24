using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _spread;
    [SerializeField] private int _bulletsPerShot;
    
    public override void Shoot(Transform shootingPoint)
    {
        Vector3 originalEuler = shootingPoint.rotation.eulerAngles;
        for (int i = 0; i < _bulletsPerShot; i++)
        {
            float randomOffset = Random.Range(-_spread, _spread);
            float newZ = originalEuler.z + randomOffset;
            Quaternion newRotation = Quaternion.Euler(new Vector3(originalEuler.x, originalEuler.y, newZ));
            
            Instantiate(Bullet, shootingPoint.position, newRotation);
        }
    }
}
