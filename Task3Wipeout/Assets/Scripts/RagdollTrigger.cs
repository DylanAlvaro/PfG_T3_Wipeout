using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RagdollTrigger : MonoBehaviour
{
  [SerializeField] private CharacterController characterController;
  private Ragdoll ragdoll;

  private Vector3 spawnPoint = new Vector3(-20.4f, 6.30f, -24.75f);
  
  private void OnTriggerEnter(Collider other)
   {
      Ragdoll ragdoll = other.GetComponentInParent<Ragdoll>();
      if(ragdoll != null)
      {
         ragdoll.ragdollOn = true; 
         characterController.enabled = false;
         //StartCoroutine(Respawn_Coroutine());
         //Debug.Log("shouldnt move");
      }
      else
      {
         ragdoll.ragdollOn = false;
         
      }
   }

   
}
