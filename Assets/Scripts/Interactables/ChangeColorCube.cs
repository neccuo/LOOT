using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : Interactable
{
    MeshRenderer mesh;
    public Color[] colors;
    private int colorIndex;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
    }

    protected override void Interact()
    {
        colorIndex = (colorIndex+1) % colors.Length;

        mesh.material.color = colors[colorIndex];
    }
}
