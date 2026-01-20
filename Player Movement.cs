using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private CharacterController controller;

    public float speed = 12f; 
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    
    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f,0f,0f);


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //reset velocity when on the ground
        if(isGrounded && velocity.y < 0)
        {
          velocity.y = -2f;  
        }

        //getting the movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //setting the movement direction
        Vector3 move = transform.right * x + transform.forward * z;

        //actually moving the player
        controller.Move(move * speed * Time.deltaTime);

        //check if the player the player can jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {   
            //actual jump velocity calculation (let's us jump a certain height)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //applying velocity to the player
        velocity.y = velocity.y + gravity * Time.deltaTime;

        //applying the gravity to the player
        controller.Move(velocity * Time.deltaTime);