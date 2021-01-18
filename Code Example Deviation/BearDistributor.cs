using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDistributor : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Trigger> alltriggers;
    public List<receiveBullet> allReceiveBullet;
    public GameObject bear;
    public GameObject firePoint;
    public Transform player;
    public Transform gunContainer;
    public Transform fpsCam;
    public int numberBear;

    void Start()
    {
        numberBear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool allTriggerActivated = true;
        // check all possible triggers before activating the object
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
        if (allTriggerActivated && numberBear == 0)
        {
            StartCoroutine(SpawnBear());
        }
    }

    // Make Bear spawns 
    IEnumerator SpawnBear()
    {     
        while (numberBear < 10000) {
            GameObject oneBear = Instantiate(bear, firePoint.transform.position, Quaternion.identity);
            Pick pickBear = oneBear.GetComponent<Pick>();
            pickBear.player = player;
            pickBear.gunContainer = gunContainer;
            pickBear.fpsCam = fpsCam;
            numberBear++;
            yield return new WaitForSeconds(0.00001f);
        }
    }
}
