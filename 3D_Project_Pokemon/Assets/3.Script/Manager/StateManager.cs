using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Idle,
    Move,
    Run,
    LeftTurn,
    RightTurn
}
public interface Istate
{
    void EnterState();
    void UpdateState();
    void ExitState();

}
public class StateManager : MonoBehaviour
{
    private State currentState;
    private Dictionary<State, Istate> StateDictionary;
    private void Awake()
    {
        currentState = State.Idle;
        StateDictionary = new Dictionary<State, Istate>();

        StateDictionary.Add(State.Idle, new IdleState());
        StateDictionary.Add(State.Move, new MoveState());
        StateDictionary.Add(State.Run, new RunState());
        StateDictionary.Add(State.LeftTurn, new LeftTurnState());
        StateDictionary.Add(State.RightTurn, new RightTurnState());
    }
    public void ChangeState(State newState)
    {
        StateDictionary[currentState].ExitState();
        currentState = newState;
        StateDictionary[currentState].EnterState();
    }
    public void UpdateState()
    {
        StateDictionary[currentState].UpdateState();
    }
}
public class IdleState : Istate

{
    public void EnterState()
    {
        
    }
    public void UpdateState()
    {

    }
    public void ExitState()
    {

    }
}
public class MoveState : Istate
{
    public void EnterState()
    {
        PlayerControl.Instance.StartMoveAni();
    }
    public void UpdateState()
    {
        
    }
    public void ExitState()
    {
        PlayerControl.Instance.EndMoveAni();
    }
}
public class RunState : Istate
{


    public void EnterState()
    {
        PlayerControl.Instance.StartRunAni();
    }
    public void UpdateState()
    {

    }
    public void ExitState()
    {
        PlayerControl.Instance.EndRunAni();

    }
}
public class LeftTurnState : Istate
{
    public void EnterState()
    {
        PlayerControl.Instance.StartLeftTurn();
    }
    public void UpdateState()
    {

    }
    public void ExitState()
    {
        PlayerControl.Instance.EndLeftTurn();

    }
}
public class RightTurnState : Istate
{
    public void EnterState()
    {
        PlayerControl.Instance.StartRightTurn();
    }
    public void UpdateState()
    {

    }
    public void ExitState()
    {
        PlayerControl.Instance.EndRightTurn();

    }
}