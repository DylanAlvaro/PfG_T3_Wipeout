using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Serialization;

public class RagdollTrigger : MonoBehaviour
{
  [SerializeField] private CharacterController[] characterController;
  [SerializeField] private Camera camera;
  private Ragdoll ragdoll;
  private CharacterMover player;

  private void OnTriggerEnter(Collider other)
   {
      Ragdoll ragdoll = other.GetComponentInParent<Ragdoll>();

      for(int i = 0; i < characterController.Length; i++)
      {
	      if(ragdoll != null)
	      {
		      ragdoll.ragdollOn = true; 
		      characterController[i].enabled = false;
	      }
      }
     
   }

   
}
