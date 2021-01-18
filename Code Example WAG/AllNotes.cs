using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AllNotes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject note;
    public GameObject notePad;
    public Dialogue dialogueManager;
    private float posX;
    private float posY;
    private float posZ;

    void Start()
    {
        posX = -90f;
        posY = 20f;
        posZ = 0f;
    }

    public void CreateNotes(String answerLong, String answerBrief, int category, int id)
    {
        GameObject oneNote = Instantiate(note, new Vector3(0,0,0), Quaternion.identity);
        Answer response = oneNote.GetComponent<Answer>();
        RectTransform rectTransform = oneNote.GetComponent<RectTransform>();
        rectTransform.transform.SetParent(notePad.transform);
        rectTransform.anchoredPosition3D = new Vector3(posX,posY,posZ);
        rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        rectTransform.localScale = new Vector3(1,1,1);
        response.answerBrief = answerBrief;
        response.answerLong = answerLong;
        response.category = category;
        response.dialogueManager = dialogueManager;
        response.id = id;
        response.isDestructible = true;
        posY -= 40;
//        oneNote.transform.position = new Vector3(posX, posY, posZ);
    }

}
