using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public CharacterMover player;

   // when the player walks int the checkpoint it changes the players respanw. 
   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player"))
      { 
         player.SetRespawnPoint(gameObject.transform.position + new Vector3(1, 0, 0));
      }
   }
}