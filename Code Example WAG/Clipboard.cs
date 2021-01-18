using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator clipboardAnim;
    public bool isActive;
 
    void Start()
    {
        isActive = false;
        clipboardAnim = GetComponent<Animator>();
    }

    public void ClipboardIn()
    {
        isActive = true;
        clipboardAnim.SetBool("isClipboardIn", true);
    }

    public void ClipboardOut()
    {
        isActive = false;
        clipboardAnim.SetBool("isClipboardIn", false);
    }
}
