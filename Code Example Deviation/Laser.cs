using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Laser : MonoBehaviour
{

    public int reflections;
    public float maxLength;

    private LineRenderer LineRenderer;
    private Ray Ray;
    private RaycastHit hit;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Creates ray with multiple reflections on each surface collided with
        Ray = new Ray(transform.position, transform.forward);

        LineRenderer.positionCount = 1;
        LineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++) {
            if (Physics.Raycast(Ray.origin, Ray.direction, out hit, remainingLength)) {
                if (hit.collider.tag.Equals("LaserReceiver")) {
                    hit.transform.SendMessage("Activation"); // send Message to Laser Receiver to say it hit him
                }
                LineRenderer.positionCount += 1;
                LineRenderer.SetPosition(LineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(Ray.origin, hit.point);
                Ray = new Ray(hit.point, Vector3.Reflect(Ray.direction, hit.normal));

                    // if (hit.collider.tag != "Mirror")
                    //     break;
            } else {
                LineRenderer.positionCount += 1;
                LineRenderer.SetPosition(LineRenderer.positionCount - 1, 
                    Ray.origin + Ray.direction * remainingLength);
            }
        }
    }
}
