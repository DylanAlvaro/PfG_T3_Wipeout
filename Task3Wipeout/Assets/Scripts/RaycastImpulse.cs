using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;

using UnityEngine;

public class RaycastImpulse : MonoBehaviour
{
    public float hitForce = 500;
    public Ray ray;
    public Vector3 offset;
    private Camera _camera;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Door"))
       {
           if (Input.GetMouseButtonDown(0))
           {
               Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

               if (Physics.Raycast(ray, out RaycastHit hit))
               {
                   if(hit.collider.gameObject.GetComponent<Door>() != null)
                   {
                       Vector3 distToTarget = hit.point - transform.position;
                       Vector3 forceDir = distToTarget.normalized;
                       
                       rb.AddForce(forceDir * hitForce, ForceMode.Impulse);
                   }
               }
           }
       }
   }


   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
