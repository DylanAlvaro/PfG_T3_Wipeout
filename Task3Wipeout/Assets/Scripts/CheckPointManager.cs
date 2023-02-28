using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

   
    public GameObject UI;
    
    private Vector3 spawn;


    private void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }
}
