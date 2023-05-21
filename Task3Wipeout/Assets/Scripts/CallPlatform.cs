using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class CallPlatform : MonoBehaviour
{
	private Animator animator;
	private CharacterMover player;
	private float raycastDst = 100f;

	private void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		RaycastHit hit;
		if (Physics.Raycast(player.transform.position, Vector3.down, out hit, raycastDst))
		{
			if (other.CompareTag("Floor"))
			{
				animator.SetTrigger("Active");
			}
		}
	}
}
