using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public Animator transitionanim;
    
    DialogueController dc;


    [Header("Start Scene")]
    public float waitTime = 4f;
    [Header("End Scene")]
    public string nextScene;

    private void Start()
    {
        dc = GetComponent<DialogueController>();
        StartCoroutine("StartScene");
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(waitTime);
        dc.StartDialogues();
    }
    private void Update()
    {
        if (dc.dialoguesEnded)
        {
            StopAllCoroutines();
            StartCoroutine("EndScene");
        }
    }
    IEnumerator EndScene()
    {
        transitionanim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
        Debug.Log("NextSceneLoaded");
    }
}
