using UnityEngine;
using UnityEngine.Serialization;

public class ChangeMaterialBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("OldMaterial")] public Material oldMaterial;
    [FormerlySerializedAs("NewMaterial")] public Material newMaterial;

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = oldMaterial;
    }

    private void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material = newMaterial;
    }
}