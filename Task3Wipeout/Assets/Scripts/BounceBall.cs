using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{ 
			other.GetComponent<CharacterMover>().velocity = -other.GetComponent<CharacterMover>().velocity * 1.2f;
		}
	}
}
