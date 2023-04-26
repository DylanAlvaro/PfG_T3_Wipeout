using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float camSpeed = 360;
    public float distance = 5;
    public Transform target;
    public float currentDistance;

    public List<Transform> objectsToFollow;
    public int currentCharaterList = 0;

    public Ragdoll ragdoll;

    public float heightOffset = 1.5f;
    
   
    
    private Vector2 moveInput = new Vector2();
   
    
    // Start is called before the first frame update
    void Start()
    {
        currentDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            float dx = Input.GetAxis("Mouse Y");
            float dy = Input.GetAxis("Mouse X");

            angles.x = Mathf.Clamp(angles.x + dx * camSpeed * Time.deltaTime, 0, 70);
            angles.y += dy * camSpeed * Time.deltaTime;
            transform.eulerAngles = angles;
        }
        
        RaycastHit hit;
        if(Physics.Raycast(GetTargetPosition(), -transform.forward, out hit, distance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime);
        }

       // transform.position = GetTargetPosition() - distance * transform.forward;

        if(objectsToFollow.Count > 0)
        {
            transform.position = new Vector3(objectsToFollow[currentCharaterList].position.x,
                                             objectsToFollow[currentCharaterList].position.y,
                                             objectsToFollow[currentCharaterList].position.z
                                            );
        }
    }
    
    private Vector3 GetTargetPosition()
    {
        if(objectsToFollow[currentCharaterList].GetComponent<Ragdoll>().ragdollOn)
        {
           return objectsToFollow[currentCharaterList].GetChild(0).GetChild(1).transform.position + heightOffset * Vector3.up;
        }
        else
        { 
            return objectsToFollow[currentCharaterList].position + heightOffset * Vector3.up;
        }
    }

    public void SetCurrentPlayer(int index)
    {
        if(index < objectsToFollow.Count)
        {
            currentCharaterList = index;
        }
    }
}
