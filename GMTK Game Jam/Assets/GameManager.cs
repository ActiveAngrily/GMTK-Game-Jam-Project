using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Camera cam;

    #region public readonly properties
    public Vector2 cursorWorldposition { get; private set; }
    public Transform PlayerTransform { get; private set; }

    #endregion


    [SerializeField] GameObject player;





    private void Awake()
    {
        instance = this;
        cam = Camera.main;
    }



    private void Update()
    {
        PlayerTransform = player.transform;
        cursorWorldposition = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
