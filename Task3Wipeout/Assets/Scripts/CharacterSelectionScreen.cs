using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionScreen : MonoBehaviour
{
    public Material changeMat;
    public Button btn;

    public void ChangeMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = changeMat;
    }
}
