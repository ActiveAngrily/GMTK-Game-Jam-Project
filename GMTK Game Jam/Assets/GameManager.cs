using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform PlayerTransform { get; private set; }

    [SerializeField] GameObject player;

    private void Update()
    {
        PlayerTransform = player.transform;
    }
}
