using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected State _targetState;
    
    protected Player Target {get; set;}
    
    public State TargetState => _targetState;

    public bool NeedTransit {get; protected set; }

    public void Init(Player player)
    {
        Target = player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
