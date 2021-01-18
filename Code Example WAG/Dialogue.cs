using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [Serializable]
    public struct BotAnswer
    {
        public string answerBrief;
        public string answerLong;
        public int category;
        public int id;
    }
    public AllNotes playerNote;
    public TextMeshProUGUI textDisplayPlayer;
    public TextMeshProUGUI textDisplayBot;
    public GameObject dialogueBot;
    public GameObject dialoguePlayer;
    public AudioClip[] soundScribbles;
    public AudioSource soundScribble;
    public AudioClip soundSpeech;
    public AudioClip soundSpeechBot;
    public AudioSource sourceDestroyAnswer;
    public AudioClip soundDestroyAnswer;
    public AudioSource sourceSpeech;
    private Animator BotAnimator;
    private Animator PlayerAnimator;
    private BotAnswer botAnswerData;
    [HideInInspector]
    public bool botStartTalk;
    [HideInInspector]
    public bool playerIsTalking; // Enlevable pour faire un gameplay en lui même
    public float typingSpeed;
    public bool playerInDialogue;
    public string playerAnswer;
    private string botAnswer;
    [HideInInspector]
    public int categoryPlayer;
    [HideInInspector]
    public int categoryBot;
    [HideInInspector]
    public int idPlayer;
    [HideInInspector]
    public int idBot;
    [HideInInspector]
    public string BotAnswerBrief;
    [HideInInspector]
    public string BotAnswerLong;


    // Start is called before the first frame update
    void Start()
    {
        playerIsTalking = false;
        botStartTalk = false;
        BotAnimator = dialogueBot.GetComponent<Animator>();
        PlayerAnimator = dialoguePlayer.GetComponent<Animator>();
    }

    public void DialogueStart()
    {
        textDisplayPlayer.text = null;
        textDisplayBot.text = null;
        playerAnswer = null;
        botAnswer = null;
        BotAnimator.SetBool("isOpen", true);
        PlayerAnimator.SetBool("isOpen", true);
    }

    public void DialogueEnd()
    {
        textDisplayPlayer.text = null;
        textDisplayBot.text = null;
        playerAnswer = null;
        botAnswer = null;
        playerIsTalking = false;
        botStartTalk = false;
        BotAnimator.SetBool("isOpen", false);
        PlayerAnimator.SetBool("isOpen", false);
    }

    public void PlayerTalk(string answerLong, int category, int id)
    {
        if (playerInDialogue) {
            playerIsTalking = true;
            textDisplayPlayer.text = null;
            playerAnswer = answerLong;
            StartCoroutine(TypePlayer());
            categoryPlayer = category;
            idPlayer = id;
        }
    }

    public void BotTalk(string _botAnswer, BotAnswer data)
    {
        textDisplayBot.text = null;
        botAnswer = _botAnswer;
        botAnswerData = data;
//        if (botAnswer == "Marc c'est suicidé chez lui")
            // change sound bot talk
        StartCoroutine(TypeBot());
    }

    IEnumerator TypePlayer()
    {
        sourceSpeech.clip = soundSpeech;
        foreach (char letter in playerAnswer) {
            textDisplayPlayer.text += letter;
            sourceSpeech.Play();
            yield return new WaitForSeconds(typingSpeed);
        }
        botStartTalk = true;
    }

    IEnumerator TypeBot()
    {
        sourceSpeech.clip = soundSpeechBot;
        botStartTalk = false;
        float waitTime = 1f;
        float counter = 0;

        while (counter < waitTime) {
            counter += Time.deltaTime;
            yield return null;
        }
        foreach (char letter in botAnswer) {
            textDisplayBot.text += letter;
            sourceSpeech.Play();
            yield return new WaitForSeconds(typingSpeed);
        }
        if (botAnswerData.category != 0) {
            playerNote.CreateNotes(botAnswerData.answerLong, botAnswerData.answerBrief,
                botAnswerData.category, botAnswerData.id);
            soundScribble.clip = soundScribbles[UnityEngine.Random.Range(0, soundScribbles.Length)];
            soundScribble.Play();
        }
        playerIsTalking = false;
    }

    public void playSoundDestroy()
    {
        sourceDestroyAnswer.clip = soundDestroyAnswer;
        sourceDestroyAnswer.Play();
    }
}
