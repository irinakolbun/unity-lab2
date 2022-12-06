using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = 9.81f;

    private CharacterController characterController;
    public Camera camera;
    private Vector3 moveDirection = Vector3.zero;

    public static PlayerController instance;
    public static bool hasBeenInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasBeenInstantiated)
        {
            Instantiate(gameObject);
        }
        
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            moveDirection = (transform.forward * v) + (transform.right * h);
            moveDirection = moveDirection.normalized * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }

        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);
        this.LookRotation(transform, camera.transform);
    }

    public void LookRotation(Transform character, Transform camera)     
    {
        float yRot = Input.GetAxis("Mouse X") * 2f;
        float xRot = Input.GetAxis("Mouse Y") * 2f;
        character.localRotation *= Quaternion.Euler(0f, yRot, 0f);
        camera.localRotation *= Quaternion.Euler(-xRot, 0f, 0f);
        camera.localRotation = ClampRotationAroundXAxis(camera.localRotation);
    }     

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -90f, 90f);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }
 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        hasBeenInstantiated = true;
    }
}