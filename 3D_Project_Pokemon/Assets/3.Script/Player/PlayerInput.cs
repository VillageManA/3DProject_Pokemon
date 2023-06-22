using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    private StateManager stateManager;


    private void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                stateManager.ChangeState(State.Run);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().RunTo(transform.forward);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(0, -5f, 0);
                stateManager.ChangeState(State.LeftTurn);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().RunTo(-transform.right);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                stateManager.ChangeState(State.Run);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().RunTo(-transform.forward);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(0, 5f, 0);
                stateManager.ChangeState(State.RightTurn);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().RunTo(transform.right);
            }
            else
            {
                stateManager.ChangeState(State.Idle);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                stateManager.ChangeState(State.Move);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.forward);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                stateManager.ChangeState(State.LeftTurn);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.right);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                stateManager.ChangeState(State.Move);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.forward);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                stateManager.ChangeState(State.RightTurn);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.right);


            }
            else
            {
                stateManager.ChangeState(State.Idle);
            }
        }
        stateManager.UpdateState();

    }
}
