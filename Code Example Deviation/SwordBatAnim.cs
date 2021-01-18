using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBatAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public DeviateZone deviate;
    public SwordBat swordBat;
    public TrailRenderer trail;

    void Start()
    {
    }

    // Multiple functions used in animations
    public void ReflectOn()
    {
        deviate.isActive = true;
        deviate.col.enabled = true;
    }

    public void ReflectOff()
    {
        deviate.isActive = false;
        deviate.col.enabled = false;

    }

    public void IsAttackingOff()
    {
        swordBat.isAttacking = false;

    }

    public void TrailOn()
    {
        trail.enabled = true;
    }

    public void TrailOff()
    {
        trail.enabled = false;
    }
}
