using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed = 0.02f;
    public float waitTime = 5f;
    private void Start()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
        yield return new WaitForSeconds(waitTime);
        NextSentence();
    }
    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StopCoroutine(Type());
            StartCoroutine(Type());
        } else {
            textDisplay.text = "";
        }
    }
}
