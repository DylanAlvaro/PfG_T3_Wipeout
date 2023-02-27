using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    public GameObject CheckPoint;

    private Vector3 spawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
