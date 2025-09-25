using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private const string CelebrationAnimationName = "Celebration";
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(CelebrationAnimationName);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
