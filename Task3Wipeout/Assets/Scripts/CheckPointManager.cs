using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public bool inCP = false;

    private CharacterMover move;
    
    public List<GameObject> checkPoints;
    public GameObject checkPoint;
    private Vector3 spawn;
    
    private void Start()
    {
        spawn = move.spawnPoint;
    }

    private void Update()
    {
        if(gameObject.transform.position.y < -20f)
        {
            //gameObject.transform.position = spawn;
            move.spawnPoint = spawn;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint2"))
        {
            Debug.Log("went into checkpoint");
            inCP = true;
            spawn = checkPoint.transform.position;
        }
    }
}
