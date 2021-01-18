using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receiveBullet : MonoBehaviour
{
    public bool activated;
    private MeshRenderer mesh;
    public Material activatedMat;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // On trigger with bullet destroys the bullet and activate the trigger
    void OnTriggerEnter(Collider obj) 
    {
        if (!activated && obj.gameObject.tag == "Bullet") {
            activated = true;
            mesh.material = activatedMat;
            Destroy(obj.gameObject);
        }
    }
}
