using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed = 2;
    public float jumpVelocity = 2;
    public Vector3 velocity;

    public Transform cam;

    [SerializeField] private CharacterController characterController;
    private Ragdoll ragdoll;

    private Vector3 spawnPoint = new Vector3(-20.4f, 6.30f, -24.75f);

    private Animator animator;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput;

    public bool isGrounded = false;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
        
        animator.SetFloat("Forwards", moveInput.y);
        animator.SetBool("Jump", !isGrounded);
    }

    public Vector3 hitDir;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitDir = hit.point - transform.position;
    }

    private void FixedUpdate()
    {
        //jumpVelocity = Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpVelocity);

        Vector3 delta;
        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        
        delta = (moveInput.x * camRight + moveInput.y * camForward) * movementSpeed;

        if(isGrounded || moveInput.x != 0 || moveInput.y != 0)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }
        
        if(jumpInput && isGrounded)
        {
            velocity.y = jumpVelocity;
        }


        if(isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity += Physics.gravity * Time.fixedDeltaTime;

        if(!isGrounded)
            hitDir = Vector3.zero;

        if(moveInput.x == 0 && moveInput.y == 0)
        {
            Vector3 horizontalHitDir = hitDir;
            horizontalHitDir.y = 0;
            float displacement = horizontalHitDir.magnitude;

            if(displacement > 0)
            {
                velocity -= 0.2f * horizontalHitDir / displacement;
            }
        }

        if(ragdoll != null)
        {
            ragdoll.ragdollOn = true;
            StartCoroutine(Respawn_Coroutine());
            characterController.enabled = false;
        }
        
        IEnumerator Respawn_Coroutine()
        {
            yield return new WaitForSeconds(3.5f);

            ragdoll.ragdollOn = false;
            characterController.enabled = true;
            gameObject.transform.position = spawnPoint;
      
        }
        
        transform.forward = camForward;
        
        //delta += velocity * Time.fixedDeltaTime;

        characterController.Move(velocity * Time.deltaTime);
        isGrounded = characterController.isGrounded;
    }
    
   
}
