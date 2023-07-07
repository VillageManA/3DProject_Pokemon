using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEvent : MonoBehaviour
{
    public UnityEvent onBallEvent;
    public void Ball_Throw()
    {
        onBallEvent?.Invoke();
    }
}
