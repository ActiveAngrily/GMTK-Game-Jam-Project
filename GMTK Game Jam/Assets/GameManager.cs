using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform PlayerTransform { get; private set; }

    [SerializeField] GameObject player;

    private void Update()
    {
        PlayerTransform = player.transform;
    }
}
