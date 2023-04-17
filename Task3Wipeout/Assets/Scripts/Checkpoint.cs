using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public CharacterMover player;
   public TextMeshProUGUI text;
   
   private void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag("Player"))
      {
         text.text = ("test");
         if(Input.GetKeyDown(KeyCode.Z))
         { 
            player.SetSpawnPoint(gameObject.transform.position + new Vector3(1, 0, 0));
         }
      }
   }
}
