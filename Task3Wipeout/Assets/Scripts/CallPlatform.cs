using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class CallPlatform : MonoBehaviour
{
	private Animator animator;
	public CharacterController player;
	private static readonly int active = Animator.StringToHash("Active");

	private void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	/// <summary>
	/// animation plays when players 'playerpoint' colliders with the platform
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("playerPoint"))
		{
			animator.SetBool("isActive", true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("playerPoint"))
		{
			animator.SetBool("isActive", false);
		}
	}
}