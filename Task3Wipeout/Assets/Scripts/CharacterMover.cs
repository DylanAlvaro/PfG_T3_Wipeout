using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed = 2;
    public float jumpVelocity = 2.5f;
    public Vector3 velocity;

    public Transform cam;

    public Transform target;
    
    [SerializeField] private CharacterController characterController;
    private Ragdoll ragdoll;

    public Vector3 spawnPoint = new Vector3(-28.67f, 6.33f, -22.56f);

    public Vector3 respawnPoint = new Vector3(1.59f, 6.33f, 32.8f );
    private Animator animator;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput;

    public bool isGrounded = false;

    public TextMeshProUGUI UI;
    
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;

        respawnPoint = gameObject.transform.position;
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
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(ragdoll != null)
            { 
                ragdoll.ragdollOn = true;
                UI.gameObject.SetActive(true);
            }
            else
            {
                Respawn();
            }
        }

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
        
        transform.forward = camForward;
       
        characterController.Move(velocity * Time.deltaTime);
        isGrounded = characterController.isGrounded;
    }
    

   public void SetRespawnPoint(Vector3 newPos)
   {
        spawnPoint = newPos;
   }

   public void Respawn()
   {
       gameObject.transform.position = spawnPoint;
       characterController.enabled = true;
       animator.enabled = true;
   }
}
