using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSystem : MonoBehaviour
{

    public LineRenderer[] lr;
    public Transform buddyPointHolder;
    public Transform PlayerPointHolder;

    [Header("Buddy Line Points ")]
    public Transform[] bp;

    [Header("Player Line Points")]
    public Transform[] pp;

    [Range(0f,1f)]
    public float opacity;
    [Range(0f, 10f)]
    public float width;
    /*
     How this will work-
    ---buddyPoints and PlayerPoints will always be rotated towards each other(using Transform.lookat)
    ---lr will draw the point
     */

    private void Update()
    {
        buddyPointHolder.right = PlayerPointHolder.position - buddyPointHolder.position;
        PlayerPointHolder.right = buddyPointHolder.position - PlayerPointHolder.position;

        lr[0].useWorldSpace = true;
        lr[1].useWorldSpace = true;

        Vector3[] line1 = {bp[0].position, pp[0].position};
        Vector3[] line2 = { bp[1].position, pp[1].position };

        lr[0].SetPositions(line1);
        lr[1].SetPositions(line2);

        lr[0].startWidth = width;
        lr[0].endWidth = width;

        lr[1].startWidth = width;
        lr[1].endWidth = width;
    }

}
