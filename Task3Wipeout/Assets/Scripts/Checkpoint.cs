using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public CharacterMover player;

   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player"))
      {
            player.SetRespawnPoint(gameObject.transform.position + new Vector3(1, 0, 0));
      }
   }
}