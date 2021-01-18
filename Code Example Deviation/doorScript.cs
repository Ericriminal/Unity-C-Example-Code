using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public List<Trigger> alltriggers;
    public List<receiveBullet> allReceiveBullet;
    public List<ReceiveLaser> allReceiveLaser;
    public bool trigger;
    private Animator anim;

    void Start()
    {
        trigger = false;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check all possible triggers before activating the object

        bool allTriggerActivated = true;
        foreach (Trigger trig in alltriggers)
        {
            if (trig.pressed == false)
            {
                allTriggerActivated = false;
                break;
            }
        }

        foreach (receiveBullet receive in allReceiveBullet)
        {
            if (receive.activated == false)
            {
                allTriggerActivated = false;
                break;
            }
        }

        foreach (ReceiveLaser receive in allReceiveLaser)
        {
            if (receive.activated == false)
            {
                allTriggerActivated = false;
                break;
            }
        }
        // Activate the door if all Trigger activated
        if (allTriggerActivated)
        {
            trigger = true;
            anim.SetBool("activated", true);
        } else {
            anim.SetBool("activated", false);
        }
    }
}
