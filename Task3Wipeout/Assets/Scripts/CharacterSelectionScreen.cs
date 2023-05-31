using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSelectionScreen : MonoBehaviour
{
    public Material[] material;
    public Renderer[] characterRender;
    private int[] currentMatIndex;
    
    // color sliders
    public Slider red;
    public Slider blue;
    public Slider green;
    
    // Cameras
    public Camera characterSelectCam;
    public Camera MainCamera;
   
    public Transform teleportToStart;
    public GameObject UI;
    public CharacterMover player;

    public Slider smoothnessSlider;
    public Slider MetalicSlider;
    public Slider forceFieldSlider;
    public Slider dissolveSlider;

    public GameObject particleSystem;

    private Color[] _colors;

    public float originalSmoothness = 0;
    public float originalMetallic = 0;
    
    

    [Range(0, 1)]
    public float smoothness;
    [Range(0, 1)]
    public float metalic;
    [Range(0, 1)] 
    public float forceField;
    [Range(0, 1)] 
    public float dissolve;
    
    private bool isInCharacterCustomize = true;
    private void Start()
    {
        characterSelectCam.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        UI.SetActive(true);

        smoothnessSlider.value = originalSmoothness;
        MetalicSlider.value = originalMetallic;
        
        currentMatIndex = new int[characterRender.Length];

        for(int i = 0; i < characterRender.Length; i++)
        {
            characterRender[i].material = material[currentMatIndex[i]];
        }
    }

    private void Update()
    {
        if (!isInCharacterCustomize)
        {
            Vector3 offset = new Vector3(0, 2, -5);
            MainCamera.transform.position = player.transform.position + offset;
            MainCamera.transform.LookAt(player.transform.position);
        }
    }

    /// <summary>
    /// When the user presses on the confirm button in game this teleport function is called and the firs
    /// </summary>
    public void Teleport()
    {
        player.transform.position = teleportToStart.transform.position;
        
        characterSelectCam.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);
        
        UI.SetActive(false);

        isInCharacterCustomize = false;
    }

    public void ChangeShader(int index)
    {
        currentMatIndex[index] = (currentMatIndex[index] + 1) % material.Length;
        characterRender[index].material = material[currentMatIndex[index]];
    }
    
    /// <summary>
    /// changes smoothness of materials
    /// </summary>
    public void ChangeSmoothness()
    {
        smoothness = smoothnessSlider.value; 
        material[0].SetFloat("_Smoothness", smoothness);
        material[1].SetFloat("_Smoothness", smoothness);
        material[2].SetFloat("_Smoothness", smoothness);
        material[3].SetFloat("_Smoothness", smoothness);
        material[4].SetFloat("_Smoothness", smoothness);
        material[5].SetFloat("_Smoothness", smoothness);
    }

    public void ChangeDissolve()
    {
        dissolve = dissolveSlider.value;
        material[2].SetFloat("_ClippingVal", dissolve);
    }
    
    // changes metallic of materials
    public void ChangeMetalic()
    {
        metalic = MetalicSlider.value; 
        material[0].SetFloat("_Metalic", metalic);
        material[1].SetFloat("_Metalic", metalic);
        material[2].SetFloat("_Metalic", metalic);
        material[3].SetFloat("_Metalic", metalic);
        material[4].SetFloat("_Metalic", metalic);
        material[5].SetFloat("_Metalic", metalic);
    }

    public void ChangeForceFieldValues()
    {
        forceField = forceFieldSlider.value;
        material[0].SetFloat("_ForceField", forceField);
        material[1].SetFloat("_ForceField", forceField);
        material[2].SetFloat("_ForceField", forceField);
        material[3].SetFloat("_ForceField", forceField);
        material[4].SetFloat("_ForceField", forceField);
        material[5].SetFloat("_ForceField", forceField);
    }

    // enables the particle system 
    public void EnableParticleSystem()
    {
        Instantiate(particleSystem, transform.position, transform.rotation);
        Debug.Log("PS Enabled");
    }

    // change rgb colors of materials
    public void ChangeColorSliders(int index)
    {
        currentMatIndex = new int[characterRender.Length];
        
        for(int i = 0; i < characterRender.Length; i++)
        {
            Color color = characterRender[index].material.color;
            color.r = red.value;
            color.g = green.value;
            color.b = blue.value;
            characterRender[index].material.color = color;
            characterRender[index].material.SetColor("_EmissionColor", color);
        }
    }
}
