using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacterColour : MonoBehaviour
{
   public Renderer render;
   public Material material;
   public Slider changeSmoothness;
   public Slider changeMetalic;
   public Slider changeColor;

   [Range(0, 1)]
   public float smoothness;
   [Range(0, 1)]
   public float metalic;
   
   public Color color;

   public void ChangeColor()
   {
       material.SetColor("_Color", color);
   }

   public void ChangeMetalic()
   {
       metalic = changeMetalic.value;
       material.SetFloat("_Metalic", metalic);
   }

   public void ChangeSmooth()
   { 
       smoothness = changeSmoothness.value; 
       material.SetFloat("_Smoothness", smoothness);
   }
}
