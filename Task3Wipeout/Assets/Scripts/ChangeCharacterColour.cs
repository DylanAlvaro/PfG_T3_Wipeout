using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacterColour : MonoBehaviour
{
   public Material material;
   public Slider colorChanger;

   private void Start()
   {
      colorChanger = this.gameObject.GetComponent<Slider>();
   }

   
}
