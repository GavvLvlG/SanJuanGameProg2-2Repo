using UnityEngine;
using UnityEngine.InputSystem; 
public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public float rotationSpeed = 5f;
    public Animator animator;

    private CharacterController controller;
    private Vector3 velocity;   
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    
    void Update()
    {
        isGrounded = controller.isGrounded; 

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveX, 0f, moveZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            controller.Move(direction * speed * Time.deltaTime);
        }

    

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }   

        velocity.y += gravity * Time.deltaTime; 

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("IsAttack");

        }


    }
}
