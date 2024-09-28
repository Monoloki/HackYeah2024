using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 30f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private GameObject lookAt;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    [SerializeField] private Animator animator;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CutSceneManager.instance.playerCamera = playerCamera;
    }

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {

        bool canMove = GameManager.instance.playerActive;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * vertical : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * horizontal : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
            moveDirection.y = jumpPower;
        }
        else {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded) {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove) {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else {
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        animator.SetBool("IsMoving",vertical != 0 || horizontal != 0);

        characterController.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        // 5 -> -2

        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            lookAt.transform.localPosition = new Vector3(0, -1 *(3f + (rotationX - 30f) * (-2f - 3f) / (-30f - 30f)), 0) ;
               
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}