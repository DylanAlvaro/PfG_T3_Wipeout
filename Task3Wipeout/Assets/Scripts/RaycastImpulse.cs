using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public class RaycastImpulse : MonoBehaviour
{
    public float hitForce = 500;
    public Ray ray;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = new Ray(transform.position + offset, transform.forward);

            RaycastHit hitPoint;
            
            if (Physics.Raycast(ray, out hitPoint, 100))
            {
                if(hitPoint.rigidbody.CompareTag("Door"))
                {
                    hitPoint.rigidbody.AddForce(ray.direction * hitForce);
                }
                
               // Rigidbody rb = hitPoint.collider.GetComponent<Rigidbody>();
               // if(rb != null)
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
