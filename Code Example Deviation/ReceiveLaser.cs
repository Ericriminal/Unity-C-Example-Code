using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activated;
    private MeshRenderer mesh;
    public Material activatedMat;

    void Start()
    {
        activated = false;
        mesh = GetComponent<MeshRenderer>();
    }

    public void Activation()
    {
        activated = true;
        mesh.material = activatedMat;
    }
}
