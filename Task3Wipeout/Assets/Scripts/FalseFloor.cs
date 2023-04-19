using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFloor : MonoBehaviour
{
    public float fallDownSpeed = 1f;

    private bool playerOnPlatform = false;
    public Animation falldownAnim;
    private float timeOnPlatform = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            timeOnPlatform += Time.deltaTime;
            transform.Translate(Vector3.down * fallDownSpeed * timeOnPlatform * Time.deltaTime );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            timeOnPlatform = 0;
        }
    }
}
