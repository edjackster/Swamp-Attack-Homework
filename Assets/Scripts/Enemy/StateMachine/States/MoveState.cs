using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    private const string WalkAnimationName = "Walk";
    
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(WalkAnimationName);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    private void Update()
    {
        if(Target == null)
            return;
        
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * _speed);
    }
}
