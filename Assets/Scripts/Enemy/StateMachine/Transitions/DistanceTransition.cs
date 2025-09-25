using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionDistance;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionDistance += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if(Target == null)
            return;
        
        if (Vector2.Distance(transform.position, Target.transform.position) <= _transitionDistance)
            NeedTransit = true;
    }
}
