using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeMaterialBehaviour : MonoBehaviour
{
    [SerializeField] private Material oldMaterial;
    [SerializeField] private Material newMaterial;
    [SerializeField]
    private List<MeshRenderer> meshRenderers;


    private void Start()
    {
        if (meshRenderers.Count <= 0)
            meshRenderers.Add(GetComponent<MeshRenderer>());
    }

    private void OnMouseExit()
    {
        
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material = oldMaterial;
        }
            
    }

    private void OnMouseOver()
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material = newMaterial;
        }
    }
}