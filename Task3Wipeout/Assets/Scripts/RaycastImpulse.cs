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

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint, 500))
            {
                if (hitPoint.collider.gameObject.GetComponent<PennBall>() != null)
                {
                    Rigidbody rb = hitPoint.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.AddForce(ray.direction * hitForce);
                }
            }
        }
    }
    
   // private void OnTriggerEnter(Collider other)
   //{
   //    //if (other.CompareTag("Door"))
   //    //{
   //        if (Input.GetMouseButtonDown(0))
   //        {
   //            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
   //
   //            if (Physics.Raycast(ray, out RaycastHit hit))
   //            {
   //                if(hit.collider.gameObject.GetComponent<Door>() != null)
   //                {
   //                    Vector3 distToTarget = hit.point - transform.position;
   //                    Vector3 forceDir = distToTarget.normalized;
   //                    rb.AddForce(forceDir * hitForce, ForceMode.Impulse);
   //                }
   //            }
   //        }
   //    //}
   //}


   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
