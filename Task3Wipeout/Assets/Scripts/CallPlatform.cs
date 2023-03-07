using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class CallPlatform : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
			animator.SetTrigger("Active");
	}
}
