using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBounceBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
            other.GetComponent<CharacterMover>().velocity = -other.GetComponent<CharacterMover>().velocity * 10;
        }
    }
}
