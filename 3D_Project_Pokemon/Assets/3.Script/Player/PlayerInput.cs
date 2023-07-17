using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInput : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float jumpSpeed;
    public float gravity;
    public float rotationSpeed;

    private CharacterController controller;
    private Vector3 moveDirection;
    [SerializeField] private Transform cameraTransform;

    private StateManager stateManager;


    private void Awake()
    {
        speed = 3.0f;
        runspeed = 2;
        jumpSpeed = 8.0f;
        gravity = 20.0f;
        rotationSpeed = 1.0f;

        controller = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;


        stateManager = FindObjectOfType<StateManager>();

    }
    private void Start()
    {
        if (cameraTransform == null)
        {
            GameObject mainCamera = Camera.main.gameObject;
            cameraTransform = mainCamera.transform;
        }
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (cameraTransform == null)
            {
                GameObject mainCamera = Camera.main.gameObject;
                cameraTransform = mainCamera.transform;
            }

            moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
            moveDirection = cameraTransform.TransformDirection(moveDirection);
            moveDirection.y = 0f;
            moveDirection.Normalize();

            float currentSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
                currentSpeed *= runspeed;

            moveDirection *= currentSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            if (verticalInput >= 0f)
            {
                RotatePlayer(moveDirection);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        UpdateState();

    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void UpdateState()
    {

        if (moveDirection.magnitude > 0.4f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                stateManager.ChangeState(State.Run);
            else
                stateManager.ChangeState(State.Move);
        }
        else
        {
            stateManager.ChangeState(State.Idle);
        }
    }
}
