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

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("playerPoint"))
		{
			animator.SetTrigger(active);
		}
	}
}