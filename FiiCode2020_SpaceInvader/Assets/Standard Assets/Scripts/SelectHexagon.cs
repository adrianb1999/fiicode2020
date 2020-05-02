using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHexagon : MonoBehaviour
{
    Material currentMaterial;
    [SerializeField] Material showMaterial;
    [SerializeField] HexaManager hexaManager;
    MeshRenderer currentMesh;
    private void Awake()
    {
        currentMesh = GetComponent<MeshRenderer>();
        currentMaterial = currentMesh.material;
        hexaManager = FindObjectOfType<HexaManager>();
    }
    void OnMouseOver()
    {
        currentMesh.material = showMaterial;
        hexaManager.coordonates = transform.position;
        hexaManager.rotation = transform.rotation;
    }

    void OnMouseExit()
    {
        currentMesh.material = currentMaterial;
    }
}
