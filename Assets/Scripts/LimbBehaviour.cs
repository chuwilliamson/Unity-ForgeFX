using System;
using UnityEngine;

public class LimbBehaviour : MonoBehaviour   
{
    [field: SerializeField]
    public bool Attached { get; set; }

    private void Start()
    {
        Attached = true;
        PreviousParentTransform = transform.parent;
    }

    public Transform PreviousParentTransform { get; set; }
}