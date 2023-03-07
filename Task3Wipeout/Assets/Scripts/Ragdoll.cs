using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Ragdoll : MonoBehaviour
{

    private Animator animator = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private CharacterController characterController;
    public Vector3 spawnPoint = new Vector3(-20.4f, 6.30f, -24.75f);
    
    public bool ragdollOn
    {
        get { return !animator.enabled;}
        set { animator.enabled = !value;
            foreach (Rigidbody rb in rigidbodies)
                rb.isKinematic = !value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            
        }
    }
}
