using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    Texture[] textures;

    int textureIndex;

    [SerializeField]
    float fps = 24f;

    float fpsCounter;


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
        }
    }
}
