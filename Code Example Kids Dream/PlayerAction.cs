using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator swordAnim;
    public Animator shieldAnim;
    public ParticleSystem swordAttackEffect;
    public bool isAttacking;
    public bool isDefending;
    public bool isReloading;
    public bool swordOn;
    private FirstPersonAIO fp;
    private Transform setIdleReloadPoint;
    public bool youDied;
    public GameObject endingCanvas;
    public AudioSource audioShield;
    public AudioSource audioShield2;

    void Start()
    {
        fp = GetComponent<FirstPersonAIO>();
        isAttacking = false;
        swordOn = true;
        isDefending = false;
        isReloading = false;
        youDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!youDied) {
            if (!isAttacking && !isReloading
                && !isDefending && swordOn && Input.GetMouseButtonDown(0) ) {
                swordAnim.SetTrigger("isAttacking");
                isAttacking = true;
                swordAttackEffect.Play();
            }

            if (!swordOn && Input.GetKey("r")) {
                isReloading = true;
                swordAnim.SetBool("reloading", true);
                fp.playerCanMove = false;
            } else {
                isReloading = false;
                fp.playerCanMove = true;
                swordAnim.SetBool("reloading", false);
            }

            if (!isAttacking && !isReloading && Input.GetMouseButton(1)) {
                shieldAnim.SetBool("isDefending", true);
            } else {
                shieldAnim.SetBool("isDefending", false); 
            }
        } else {
            if (Input.GetKey("r")) {
                  SceneManager.LoadScene("Battle");
            }
            if (Input.GetKey("escape")) {
                Application.Quit();
            }
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "EnemySword") {
            IAMovement tmp = other.collider.GetComponent<IAMovement>();
            if (!tmp.death && tmp.isAttacking && !isDefending) {
                fp.enableCameraMovement = false;
                fp.playerCanMove = false;
                youDied = true;
                endingCanvas.SetActive(true);
            }
            if (isDefending) {
                audioShield.Play();
                audioShield2.Play();
            }
        } 
    }
}
