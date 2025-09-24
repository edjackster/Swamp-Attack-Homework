using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DistanceAttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _duration = 1f;
    
    private Animator _animator;
    private float _speed;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        var distance = Math.Abs((transform.position - Target.transform.position).magnitude);
        _speed = distance / _duration;
        _animator.Play("DistanceAttack");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
