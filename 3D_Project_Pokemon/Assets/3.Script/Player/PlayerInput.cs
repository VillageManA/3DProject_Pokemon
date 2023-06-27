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
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.forward, 10f);

            }
            else if (Input.GetKey(KeyCode.A))
            {

                transform.Rotate(Vector3.up * -90f * Time.deltaTime);
                stateManager.ChangeState(State.Run);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.right, 3f);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                stateManager.ChangeState(State.Run);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.forward, 10f);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * 90f * Time.deltaTime);
                stateManager.ChangeState(State.Run);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.right, 3f);
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
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.forward, 5f);

            }
            else if (Input.GetKey(KeyCode.A))
            {

                transform.Rotate(Vector3.up * -90f * Time.deltaTime);
                stateManager.ChangeState(State.Move);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.right, 3f);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                stateManager.ChangeState(State.Move);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(-transform.forward, 5f);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * 90 * Time.deltaTime);
                stateManager.ChangeState(State.Move);
                PlayerControl.Instance.GetComponent<PlayerMoveMent>().MoveTo(transform.right, 3f);


            }
            else
            {
                stateManager.ChangeState(State.Idle);
            }
        }
        stateManager.UpdateState();

    }
}
