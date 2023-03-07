using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public CharacterMover player;
    public List<GameObject> checkpoints;

    public Vector3 dead;
    public Vector3 newSpawn;
    private void Start()
    {
        player = FindObjectOfType<CharacterMover>();
    }

    private void Update()
    {
       if(player.transform.position.y < -20)
       {
	       player.transform.position = newSpawn;
       }
    }
    
    private void OnTriggerEnter(Collider other)
    {
	    if(other.CompareTag("Player"))
	    {
		    if(Input.GetKeyDown(KeyCode.Z)) 
			    newSpawn = player.transform.position;
	    }
    }
}
