using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] points;
    public int pointNumber = 0;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed;
    public float delayTime;

    private float delayStart;

    public bool automatic;

    void Start()
    {
        if (points.Length > 0) {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (transform.position != currentTarget) {
            MovePlatform();
        } else {
            UpdateTarget();
        }
    }

    // Move object to one target
    void MovePlatform()
    {
        Vector3 headingTo = currentTarget - transform.position;
        transform.position += (headingTo/headingTo.magnitude) * speed * Time.deltaTime;

        if (headingTo.magnitude < tolerance) {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    // Update target
   void UpdateTarget()
    {
        if (automatic) {
            if (Time.time - delayStart > delayTime) {
                NextPlatform();
            }
        }
    }

    // Set target to another target put in the "points" variable
    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length) {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
