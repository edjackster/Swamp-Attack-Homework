using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        if (enabled)
            return;

        Target = target;
        enabled = true;

        foreach (Transition transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    public State GetNext()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled == false)
            return;

        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
        }    
        
        enabled = false;
    }
}
