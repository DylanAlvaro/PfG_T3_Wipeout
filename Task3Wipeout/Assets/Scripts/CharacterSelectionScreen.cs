using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSelectionScreen : MonoBehaviour
{
    public Material[] material;
    public Renderer[] objRender;
    public int[] currentMatIndex;
    private void Start()
    {
        currentMatIndex = new int[objRender.Length];

        for(int i = 0; i < objRender.Length; i++)
        {
            objRender[i].material = material[currentMatIndex[i]];
        }
    }

    public void ChangeColor(int index)
    {
        currentMatIndex[index] = (currentMatIndex[index] + 1) % material.Length;
        objRender[index].material = material[currentMatIndex[index]];
    }
}
