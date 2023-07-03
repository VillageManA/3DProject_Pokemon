using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PokemonAnimationEvent : MonoBehaviour
{
    public UnityEvent onAttackEvent;
    public UnityEvent onDirectAttack;
    public UnityEvent onHitEvent;

    public void AttackEvent()
    {
        onAttackEvent?.Invoke();
    }
    public void DirectAttackEvent()
    {
        onDirectAttack?.Invoke();
    }
    public void HitEvent()
    {
        onHitEvent?.Invoke();
    }
}
