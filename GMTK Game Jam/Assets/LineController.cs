using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    Texture[] textures;

    int textureIndex;

    [SerializeField]
    float fps = 24f;

    float fpsCounter;

    [SerializeField]
    UnityEvent onCycleReached;


    [SerializeField]
    UnityEvent onX_thReached;


    [SerializeField]
    UnityEvent onLineRendererActive;


    [SerializeField]
    int cycleNum;

    [SerializeField]
    float duration;

    uint cycles = 0;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fpsCounter += Time.deltaTime;

        if(fpsCounter >= 1 / fps)
        {
            textureIndex++;

            if (textureIndex == textures.Length)
                textureIndex = 0;

            lineRenderer.material.SetTexture("_MainTex", textures[textureIndex]);

            fpsCounter = 0f;
            cycles++;
            onCycleReached.Invoke();
        }


        if (cycles >= cycleNum)
            onX_thReached.Invoke();
    }

   

    public void SetLinerenderertActive()
    {
        StopAllCoroutines();
        lineRenderer.enabled = true;
        textureIndex = 0;
        onLineRendererActive.Invoke();
        StartCoroutine(Disable(duration));
    }

    IEnumerator Disable(float t)
    {
        yield return new WaitForSeconds(t);
        Debug.Log("disabling laser");
        lineRenderer.enabled = false;
    }
}
