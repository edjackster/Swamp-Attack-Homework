using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _timer.StartCountdown();
        _timer.TimeOut += SelfDestroy;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Enemy enemy) == false)
            return;
        
        enemy.TakeDamage(_damage);
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        _timer.TimeOut -= SelfDestroy;
        Destroy(gameObject);
    }
}
