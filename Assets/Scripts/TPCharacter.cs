using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class TPCharacter : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationRate = 10f;
    public Transform playerCameraParent;
    public Transform playerModelParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    Vector2 lastMovingRotation = Vector2.zero;
    bool isMoving = false;

    [SerializeField] Animator animator;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 up = transform.TransformDirection(Vector3.up);
        float currSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float currSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * currSpeedX) + (up * moveDirection.y) + (right * currSpeedY);

        if (characterController.isGrounded)
        {
            animator.SetFloat("speed", new Vector2(moveDirection.x, moveDirection.z).magnitude);

            // Disabled jump
            /*if (Input.GetButton("Jump") && canMove)
            {
                animator.SetFloat("speed", 0f);
                moveDirection.y = jumpSpeed;
            }
            else
            {
                animator.SetFloat("speed", new Vector2(moveDirection.x, moveDirection.z).magnitude);
            }*/
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            // rotatin x - camerta only
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);

            // rotation y

            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            transform.eulerAngles = new Vector2(0, rotation.y);
            if (currSpeedX == 0 && currSpeedY == 0)
            {
                if (isMoving)
                {
                    lastMovingRotation = playerModelParent.eulerAngles;
                }
                playerModelParent.localEulerAngles = new Vector2(0, -rotation.y + lastMovingRotation.y);
                isMoving = false;
            }
            else
            {
                /*Debug.Log("X:" + currSpeedX + " Y: " + currSpeedY + 
                            "\nAngle: " + Vector2.Angle(Vector2.right, new Vector2(currSpeedX, currSpeedY).normalized) + " Normalized: " + new Vector2(currSpeedX, currSpeedY).normalized);*/
                float normalizedAngle = Vector2.Angle(Vector2.right, new Vector2(currSpeedX, currSpeedY).normalized);
                float magnitude = 1;
                if (currSpeedY < 0) magnitude = -1;
                // TODO 2: turn fast but not instantly
                Vector2 targetRotation = new Vector2(0, normalizedAngle * magnitude);
                float rotationNeeded = targetRotation.y - playerModelParent.localEulerAngles.y;
                float rotationDirection = 0;

                while(rotationNeeded < 0)
                {
                    rotationNeeded += 360;
                }

                if(rotationNeeded > 180)
                {
                    rotationDirection = -1;
                }
                else if(rotationNeeded > 0)
                {
                    rotationDirection = 1;
                }

                float actualrotation = rotationDirection * Time.deltaTime * rotationRate;

                if (Mathf.Abs(actualrotation) > Mathf.Abs(rotationNeeded))
                {
                    actualrotation = rotationNeeded;
                }
                Debug.Log("needed: " + rotationNeeded + " actual: " + actualrotation + " current: " + playerModelParent.localEulerAngles.y);
                if(Mathf.Abs(actualrotation) > 0)
                {
                    playerModelParent.localEulerAngles = new Vector2(playerModelParent.localEulerAngles.x, playerModelParent.localEulerAngles.y + actualrotation);
                }
                
                isMoving = true;
            }
        }
    }
}
