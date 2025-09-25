using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    private const string AttackAnimationName = "Attack";
    
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    
    private Animator _animator;
    private float _lastAttackTime;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _attackDelay;
        }
        
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(AttackAnimationName);
        target.TakeDamage(_damage);
    }
}
