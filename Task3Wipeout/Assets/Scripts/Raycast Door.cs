using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDoor : MonoBehaviour
{
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         RaycastToGameobject();
      }
   }

   private void RaycastToGameobject()
   {
      
   }
}
